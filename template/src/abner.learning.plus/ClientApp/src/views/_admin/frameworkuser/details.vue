
<template>
<div class="card-fill layout-padding">
<el-card shadow="hover" class="layout-padding-auto" >
  <div>
    <el-form ref="formRefFrameworkUser" :model="stateFrameworkUser.vmModel" label-width="100px">
      <el-row>
        <el-col :xs="24" :lg="12" class="mb20">
        <el-form-item ref="Entity_Email_FormItem" prop="Entity.Email" :label="$t('message.autotrans._Model_FrameworkUser_Email')">
            <el-input v-model="stateFrameworkUser.vmModel.Entity.Email" disabled clearable></el-input>
        </el-form-item>

        </el-col>
        <el-col :xs="24" :lg="12" class="mb20">
        <el-form-item ref="Entity_Gender_FormItem" prop="Entity.Gender" :label="$t('message.autotrans._Model_FrameworkUser_Gender')">
            <el-select v-model="stateFrameworkUser.vmModel.Entity.Gender" disabled clearable>
               <el-option key="Male" value="Male" :label="$t('message.autotrans._Enum_GenderEnum_Male')"></el-option>
               <el-option key="Female" value="Female" :label="$t('message.autotrans._Enum_GenderEnum_Female')"></el-option>
            </el-select>
        </el-form-item>

        </el-col>
        <el-col :xs="24" :lg="12" class="mb20">
        <el-form-item ref="Entity_CellPhone_FormItem" prop="Entity.CellPhone" :label="$t('message.autotrans._Model_FrameworkUser_CellPhone')">
            <el-input v-model="stateFrameworkUser.vmModel.Entity.CellPhone" disabled clearable></el-input>
        </el-form-item>

        </el-col>
        <el-col :xs="24" :lg="12" class="mb20">
        <el-form-item ref="Entity_HomePhone_FormItem" prop="Entity.HomePhone" :label="$t('message.autotrans._Model_FrameworkUser_HomePhone')">
            <el-input v-model="stateFrameworkUser.vmModel.Entity.HomePhone" disabled clearable></el-input>
        </el-form-item>

        </el-col>
        <el-col :xs="24" :lg="12" class="mb20">
        <el-form-item ref="Entity_Address_FormItem" prop="Entity.Address" :label="$t('message.autotrans._Model_FrameworkUser_Address')">
            <el-input v-model="stateFrameworkUser.vmModel.Entity.Address" disabled clearable></el-input>
        </el-form-item>

        </el-col>
        <el-col :xs="24" :lg="12" class="mb20">
        <el-form-item ref="Entity_ZipCode_FormItem" prop="Entity.ZipCode" :label="$t('message.autotrans._Model_FrameworkUser_ZipCode')">
            <el-input v-model="stateFrameworkUser.vmModel.Entity.ZipCode" disabled clearable></el-input>
        </el-form-item>

        </el-col>
        <el-col :xs="24" :lg="12" class="mb20">
        <el-form-item ref="Entity_ITCode_FormItem" prop="Entity.ITCode" :label="$t('message.autotrans._Model_FrameworkUser_ITCode')"            :rules="[{required: true, message: $t('message._system.common.vm.input',{input:$t('message.autotrans._Model_FrameworkUser_ITCode')}), trigger: 'blur' }]" >
            <el-input v-model="stateFrameworkUser.vmModel.Entity.ITCode" disabled clearable></el-input>
        </el-form-item>

        </el-col>
        <el-col :xs="24" :lg="12" class="mb20">
        <el-form-item ref="Entity_Name_FormItem" prop="Entity.Name" :label="$t('message.autotrans._Model_FrameworkUser_Name')"            :rules="[{required: true, message: $t('message._system.common.vm.input',{input:$t('message.autotrans._Model_FrameworkUser_Name')}), trigger: 'blur' }]" >
            <el-input v-model="stateFrameworkUser.vmModel.Entity.Name" disabled clearable></el-input>
        </el-form-item>

        </el-col>
        <el-col :xs="24" :lg="12" class="mb20">
        <el-form-item ref="Entity_IsValid_FormItem" prop="Entity.IsValid" :label="$t('message.autotrans._Model_FrameworkUser_IsValid')"            :rules="[{required: true, message: $t('message._system.common.vm.input',{input:$t('message.autotrans._Model_FrameworkUser_IsValid')}), trigger: 'blur' }]" >
            <el-input v-model="stateFrameworkUser.vmModel.Entity.IsValid" disabled clearable></el-input>
        </el-form-item>

        </el-col>
        <el-col :xs="24" :lg="12" class="mb20">
        <el-form-item ref="Entity_PhotoId_FormItem" prop="Entity.PhotoId" :label="$t('message.autotrans._Model_FrameworkUser_Photo')">
            <wtm-upload-image v-model="stateFrameworkUser.vmModel.Entity.PhotoId" clearable disabled style="width:300px;" thumb-width="128"/>
        </el-form-item>

        </el-col>
        <el-col :xs="24" :lg="12" class="mb20">
        <el-form-item ref="Entity_CreateTime_FormItem" prop="Entity.CreateTime" :label="$t('message.autotrans._Model_FrameworkUser_CreateTime')">
            <el-input v-model="stateFrameworkUser.vmModel.Entity.CreateTime" disabled clearable></el-input>
        </el-form-item>

        </el-col>
        <el-col :xs="24" :lg="12" class="mb20">
        <el-form-item ref="Entity_UpdateTime_FormItem" prop="Entity.UpdateTime" :label="$t('message.autotrans._Model_FrameworkUser_UpdateTime')">
            <el-input v-model="stateFrameworkUser.vmModel.Entity.UpdateTime" disabled clearable></el-input>
        </el-form-item>

        </el-col>
        <el-col :xs="24" :lg="12" class="mb20">
        <el-form-item ref="Entity_CreateBy_FormItem" prop="Entity.CreateBy" :label="$t('message.autotrans._Model_FrameworkUser_CreateBy')">
            <el-input v-model="stateFrameworkUser.vmModel.Entity.CreateBy" disabled clearable></el-input>
        </el-form-item>

        </el-col>
        <el-col :xs="24" :lg="12" class="mb20">
        <el-form-item ref="Entity_UpdateBy_FormItem" prop="Entity.UpdateBy" :label="$t('message.autotrans._Model_FrameworkUser_UpdateBy')">
            <el-input v-model="stateFrameworkUser.vmModel.Entity.UpdateBy" disabled clearable></el-input>
        </el-form-item>

        </el-col>
      </el-row>

      <div style="text-align:right;">
        <WtmButton @click="onCloseFrameworkUser"  type="primary" :button-text="$t('message.autotrans.SysClose')" style="margin-top:15px;"/>

      </div>

    </el-form>

  </div>

</el-card>
</div>
</template>


<script setup lang="ts" name="message.autotrans._Page_AdminFrameworkUserDetails;false">
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
        Email: '',
        Gender: undefined,
        CellPhone: '',
        HomePhone: '',
        Address: '',
        ZipCode: '',
        ITCode: '',
        Name: '',
        IsValid: undefined,
        PhotoId: null,
        CreateTime: undefined,
        UpdateTime: undefined,
        CreateBy: '',
        UpdateBy: '',
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

