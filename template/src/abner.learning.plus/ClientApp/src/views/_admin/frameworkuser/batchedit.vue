
<template>
<div class="card-fill layout-padding">
<el-card shadow="hover" class="layout-padding-auto" >
  <el-form ref="formRefFrameworkUser" :model="stateFrameworkUser.vmModel" label-width="100px">
    <div style="margin-bottom:10px;">{{$t('message.autotrans.SysBatchEditConfirm')}}</div>
    <el-row>
      <el-col :xs="24" :lg="12" class="mb20">
      <el-form-item ref="LinkedVM_Email_FormItem" prop="LinkedVM.Email" :label="$t('message.autotrans._Model_FrameworkUser_Email')">
          <el-input v-model="stateFrameworkUser.vmModel.LinkedVM.Email" clearable></el-input>
      </el-form-item>

      </el-col>
      <el-col :xs="24" :lg="12" class="mb20">
      <el-form-item ref="LinkedVM_Gender_FormItem" prop="LinkedVM.Gender" :label="$t('message.autotrans._Model_FrameworkUser_Gender')">
          <el-select v-model="stateFrameworkUser.vmModel.LinkedVM.Gender" clearable>
             <el-option key="Male" value="Male" :label="$t('message.autotrans._Enum_GenderEnum_Male')"></el-option>
             <el-option key="Female" value="Female" :label="$t('message.autotrans._Enum_GenderEnum_Female')"></el-option>
          </el-select>
      </el-form-item>

      </el-col>
      <el-col :xs="24" :lg="12" class="mb20">
      <el-form-item ref="LinkedVM_CellPhone_FormItem" prop="LinkedVM.CellPhone" :label="$t('message.autotrans._Model_FrameworkUser_CellPhone')">
          <el-input v-model="stateFrameworkUser.vmModel.LinkedVM.CellPhone" clearable></el-input>
      </el-form-item>

      </el-col>
      <el-col :xs="24" :lg="12" class="mb20">
      <el-form-item ref="LinkedVM_HomePhone_FormItem" prop="LinkedVM.HomePhone" :label="$t('message.autotrans._Model_FrameworkUser_HomePhone')">
          <el-input v-model="stateFrameworkUser.vmModel.LinkedVM.HomePhone" clearable></el-input>
      </el-form-item>

      </el-col>
      <el-col :xs="24" :lg="12" class="mb20">
      <el-form-item ref="LinkedVM_Address_FormItem" prop="LinkedVM.Address" :label="$t('message.autotrans._Model_FrameworkUser_Address')">
          <el-input v-model="stateFrameworkUser.vmModel.LinkedVM.Address" clearable></el-input>
      </el-form-item>

      </el-col>
      <el-col :xs="24" :lg="12" class="mb20">
      <el-form-item ref="LinkedVM_ZipCode_FormItem" prop="LinkedVM.ZipCode" :label="$t('message.autotrans._Model_FrameworkUser_ZipCode')">
          <el-input v-model="stateFrameworkUser.vmModel.LinkedVM.ZipCode" clearable></el-input>
      </el-form-item>

      </el-col>
      <el-col :xs="24" :lg="12" class="mb20">
      <el-form-item ref="LinkedVM_SelectedFrameworkUserRolesIDs_FormItem" prop="LinkedVM.SelectedFrameworkUserRolesIDs" :label="$t('message.autotrans._Model_FrameworkUser_Role')">
          <el-select v-model="stateFrameworkUser.vmModel.LinkedVM.SelectedFrameworkUserRolesIDs" multiple clearable>
             <el-option v-for="item in stateFrameworkUser.AllFrameworkUserRoles" :key="item.Value" :value="item.Value" :label="item.Text"></el-option>
          </el-select>
      </el-form-item>

      </el-col>
      <el-col :xs="24" :lg="12" class="mb20">
      <el-form-item ref="LinkedVM_SelectedFrameworkUserGroupsIDs_FormItem" prop="LinkedVM.SelectedFrameworkUserGroupsIDs" :label="$t('message.autotrans._Model_FrameworkUser_Group')">
          <el-select v-model="stateFrameworkUser.vmModel.LinkedVM.SelectedFrameworkUserGroupsIDs" multiple clearable>
             <el-option v-for="item in stateFrameworkUser.AllFrameworkUserGroups" :key="item.Value" :value="item.Value" :label="item.Text"></el-option>
          </el-select>
      </el-form-item>

      </el-col>
    </el-row>

    <div style="text-align:right;">
      <WtmButton @click="onSubmitFrameworkUser"  type="primary" :button-text="$t('message.autotrans.SysSubmit')" style="margin-top:15px;"/>

      <WtmButton @click="onCloseFrameworkUser"  type="primary" :button-text="$t('message.autotrans.SysClose')" style="margin-top:15px;"/>

    </div>

  </el-form>

</el-card>
</div>
</template>


<script setup lang="ts" name="message.autotrans._Page_AdminFrameworkUserBatchEdit;false">
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
	  LinkedVM:{
        Email: '',
        Gender: undefined,
        CellPhone: '',
        HomePhone: '',
        Address: '',
        ZipCode: '',
        SelectedFrameworkUserRolesIDs: [],
        SelectedFrameworkUserGroupsIDs: [],
      },
      Ids:[],
      
	},
    
    AllFrameworkUserRoles: [] as any[],
    AllFrameworkUserGroups: [] as any[],
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
            frameworkuserApi().batchedit(stateFrameworkUser.vmModel).then(() => {
                ElMessage.success(ci.proxy.$t('message._system.common.vm.submittip'));
                emit('refresh');
                closeDialog();
            }).catch((error:any) => {
                other.setFormError(ci, error);
            }).finally(() => {
			loadingInstance.close();
		    })
		}
	})
};


// 页面加载时
onMounted(() => {
    
    other.getSelectList('/api/_Admin/FrameworkUser/GetFrameworkRoles',[],false).then(x=>{stateFrameworkUser.AllFrameworkUserRoles = x});
    other.getSelectList('/api/_Admin/FrameworkUser/GetFrameworkGroups',[],false).then(x=>{stateFrameworkUser.AllFrameworkUserGroups = x});
    if (ci.attrs["wtmdata"]) {
		stateFrameworkUser.vmModel.Ids = ci.attrs["wtmdata"];
	}
	else if (useRouter().currentRoute.value.query.id) {
		stateFrameworkUser.vmModel.Ids = useRouter().currentRoute.value.query.id as any;
	}

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

