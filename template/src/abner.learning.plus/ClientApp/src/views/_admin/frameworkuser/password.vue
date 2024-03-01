
<template>
<div class="card-fill layout-padding">
<el-card shadow="hover" class="layout-padding-auto" >
  <el-form ref="formRefFrameworkUser" :model="stateFrameworkUser.vmModel" label-width="100px">
    <el-form-item ref="Entity_Password_FormItem" prop="Entity.Password" :label="$t('message.autotrans._Model_FrameworkUser_Password')"        :rules="[{required: true, message: $t('message._system.common.vm.input',{input:$t('message.autotrans._Model_FrameworkUser_Password')}), trigger: 'blur' }]" >
        <el-input type="password" show-password v-model="stateFrameworkUser.vmModel.Entity.Password" clearable></el-input>
    </el-form-item>

    <div style="text-align:right;">
      <WtmButton @click="onSubmitFrameworkUser"  type="primary" :button-text="$t('message.autotrans.SysSubmit')" style="margin-top:15px;"/>

      <WtmButton @click="onCloseFrameworkUser"  type="primary" :button-text="$t('message.autotrans.SysClose')" style="margin-top:15px;"/>

    </div>

  </el-form>

</el-card>
</div>
</template>


<script setup lang="ts" name="message.autotrans._Page_AdminFrameworkUserPassword;false">
import {  ElMessageBox, ElMessage,ElLoading } from 'element-plus';
import { defineAsyncComponent,reactive, ref, getCurrentInstance, onMounted, nextTick } from 'vue';
import { frameworkuserApi } from '/@/api/_admin/frameworkuser';
import other from '/@/utils/other';
import fileApi from '/@/api/file';
import { useRouter } from "vue-router";
const ci = getCurrentInstance() as any;


// 定义变量内容
const formRefFrameworkUser = ref();
const stateFrameworkUser = reactive({
    vmModel: {
	  Entity:{
        Password: '',
        ID:null,
      },

	},
    
});

// 取消
const onCloseFrameworkUser = () => {
    closeDialog();
};

// 提交
const onSubmitFrameworkUser = () => {
 	const loadingInstance = ElLoading.service({
		lock: true,
		text: '正在提交中，请等待。。。',
		background: 'rgba(0, 0, 0, 0.7)',
	});
   formRefFrameworkUser.value?.validate((valid: boolean, fields: any) => {
		if (valid) {
            frameworkuserApi().edit(stateFrameworkUser.vmModel).then(() => {
                ElMessage.success(ci.proxy.$t('message._system.common.vm.submittip'));
                emit('refresh');
                closeDialog();
            }).catch((error) => {
                other.setFormError(ci, error);
            }).finally(() => {
			loadingInstance.close();
		    })
		}
	})
};

// 页面加载时
onMounted(() => {
    
    if (ci.attrs["wtmdata"]) {
		stateFrameworkUser.vmModel.Entity.ID = ci.attrs["wtmdata"].ID;
	}
	else if (useRouter().currentRoute.value.query.id) {
		stateFrameworkUser.vmModel.Entity.ID = useRouter().currentRoute.value.query.id as any;
	}
	frameworkuserApi().get(stateFrameworkUser.vmModel.Entity.ID ?? "").then((data: any) => other.setValue(stateFrameworkUser.vmModel, data));
});

// 定义子组件向父组件传值/事件
const emit = defineEmits(['refresh','closeDialog']);
// 关闭弹窗
const closeDialog = () => {
    emit('closeDialog');
};
// 暴露变量
defineExpose({

});
</script>

<style scoped lang="scss">

</style>

