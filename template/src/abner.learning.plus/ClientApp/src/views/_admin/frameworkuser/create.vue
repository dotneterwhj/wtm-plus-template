
<template>
<div class="card-fill layout-padding">
<el-card shadow="hover" class="layout-padding-auto" >
  <el-form ref="formRefFrameworkUser" :model="stateFrameworkUser.vmModel" label-width="100px">
    <el-tabs type="border-card" >
      <el-tab-pane :label="$t('message.autotrans._AdminBasicInfo')" key="基本信息">
        <el-row>
          <el-col :xs="24" :lg="12" class="mb20">
          <el-form-item ref="Entity_ITCode_FormItem" prop="Entity.ITCode" :label="$t('message.autotrans._Model_FrameworkUser_ITCode')"              :rules="[{required: true, message: $t('message._system.common.vm.input',{input:$t('message.autotrans._Model_FrameworkUser_ITCode')}), trigger: 'blur' }]" >
              <el-input v-model="stateFrameworkUser.vmModel.Entity.ITCode" clearable></el-input>
          </el-form-item>

          </el-col>
          <el-col :xs="24" :lg="12" class="mb20">
          <el-form-item ref="Entity_Password_FormItem" prop="Entity.Password" :label="$t('message.autotrans._Model_FrameworkUser_Password')"              :rules="[{required: true, message: $t('message._system.common.vm.input',{input:$t('message.autotrans._Model_FrameworkUser_Password')}), trigger: 'blur' }]" >
              <el-input type="password" show-password v-model="stateFrameworkUser.vmModel.Entity.Password" clearable></el-input>
          </el-form-item>

          </el-col>
          <el-col :xs="24" :lg="12" class="mb20">
          <el-form-item ref="Entity_Name_FormItem" prop="Entity.Name" :label="$t('message.autotrans._Model_FrameworkUser_Name')"              :rules="[{required: true, message: $t('message._system.common.vm.input',{input:$t('message.autotrans._Model_FrameworkUser_Name')}), trigger: 'blur' }]" >
              <el-input v-model="stateFrameworkUser.vmModel.Entity.Name" clearable></el-input>
          </el-form-item>

          </el-col>
          <el-col :xs="24" :lg="12" class="mb20">
          <el-form-item ref="Entity_IsValid_FormItem" prop="Entity.IsValid" :label="$t('message.autotrans._Model_FrameworkUser_IsValid')"              :rules="[{required: true, message: $t('message._system.common.vm.input',{input:$t('message.autotrans._Model_FrameworkUser_IsValid')}), trigger: 'blur' }]" >
              <el-switch v-model="stateFrameworkUser.vmModel.Entity.IsValid" clearable></el-switch>
          </el-form-item>

          </el-col>
          <el-col :xs="24" :lg="12" class="mb20">
          <el-form-item ref="Entity_PhotoId_FormItem" prop="Entity.PhotoId" :label="$t('message.autotrans._Model_FrameworkUser_Photo')">
              <wtm-upload-image v-model="stateFrameworkUser.vmModel.Entity.PhotoId" clearable thumb-width="128"/>
          </el-form-item>

          </el-col>
        </el-row>

        <el-row>
          <el-col :xs="24" :lg="24" class="mb20">
          <el-form-item ref="SelectedFrameworkUserRolesIDs_FormItem" prop="SelectedFrameworkUserRolesIDs" :label=" $t('message.autotrans._AdminRole')">
              <el-checkbox-group v-model="stateFrameworkUser.vmModel.SelectedFrameworkUserRolesIDs" clearable>
                 <el-checkbox v-for="item in stateFrameworkUser.AllFrameworkUserRoles" :key="item.Value" :label="item.Value">{{item.Text}}</el-checkbox>
              </el-checkbox-group>
          </el-form-item>

          </el-col>
          <el-col :xs="24" :lg="24" class="mb20">
          <el-form-item ref="SelectedFrameworkUserGroupsIDs_FormItem" prop="SelectedFrameworkUserGroupsIDs" :label=" $t('message.autotrans._AdminGroup')">
              <el-cascader :options="stateFrameworkUser.AllFrameworkUserGroups"  :props="{ multiple:true,checkStrictly: true,emitPath:false,label:'Text',value:'Value',children:'Children' }" filterable class="w100" v-model="stateFrameworkUser.vmModel.SelectedFrameworkUserGroupsIDs" clearable></el-cascader>
          </el-form-item>

          </el-col>
        </el-row>

      </el-tab-pane>

      <el-tab-pane :label="$t('message.autotrans.SysExtraInfo')" key="附加信息">
        <el-row>
          <el-col :xs="24" :lg="12" class="mb20">
          <el-form-item ref="Entity_Email_FormItem" prop="Entity.Email" :label="$t('message.autotrans._Model_FrameworkUser_Email')">
              <el-input v-model="stateFrameworkUser.vmModel.Entity.Email" clearable></el-input>
          </el-form-item>

          </el-col>
          <el-col :xs="24" :lg="12" class="mb20">
          <el-form-item ref="Entity_Gender_FormItem" prop="Entity.Gender" :label="$t('message.autotrans._Model_FrameworkUser_Gender')">
              <el-select v-model="stateFrameworkUser.vmModel.Entity.Gender" clearable>
                 <el-option key="Male" value="Male" :label="$t('message.autotrans._Enum_GenderEnum_Male')"></el-option>
                 <el-option key="Female" value="Female" :label="$t('message.autotrans._Enum_GenderEnum_Female')"></el-option>
              </el-select>
          </el-form-item>

          </el-col>
          <el-col :xs="24" :lg="12" class="mb20">
          <el-form-item ref="Entity_CellPhone_FormItem" prop="Entity.CellPhone" :label="$t('message.autotrans._Model_FrameworkUser_CellPhone')">
              <el-input v-model="stateFrameworkUser.vmModel.Entity.CellPhone" clearable></el-input>
          </el-form-item>

          </el-col>
          <el-col :xs="24" :lg="12" class="mb20">
          <el-form-item ref="Entity_HomePhone_FormItem" prop="Entity.HomePhone" :label="$t('message.autotrans._Model_FrameworkUser_HomePhone')">
              <el-input v-model="stateFrameworkUser.vmModel.Entity.HomePhone" clearable></el-input>
          </el-form-item>

          </el-col>
          <el-col :xs="24" :lg="12" class="mb20">
          <el-form-item ref="Entity_Address_FormItem" prop="Entity.Address" :label="$t('message.autotrans._Model_FrameworkUser_Address')">
              <el-input v-model="stateFrameworkUser.vmModel.Entity.Address" clearable></el-input>
          </el-form-item>

          </el-col>
          <el-col :xs="24" :lg="12" class="mb20">
          <el-form-item ref="Entity_ZipCode_FormItem" prop="Entity.ZipCode" :label="$t('message.autotrans._Model_FrameworkUser_ZipCode')">
              <el-input v-model="stateFrameworkUser.vmModel.Entity.ZipCode" clearable></el-input>
          </el-form-item>

          </el-col>
        </el-row>

      </el-tab-pane>

    </el-tabs>

    <div style="text-align:right;">
      <WtmButton @click="onSubmitFrameworkUser"  type="primary" :button-text="$t('message.autotrans.SysSubmit')" style="margin-top:15px;"/>

      <WtmButton @click="onCloseFrameworkUser"  type="primary" :button-text="$t('message.autotrans.SysClose')" style="margin-top:15px;"/>

    </div>

  </el-form>

</el-card>
</div>
</template>


<script setup lang="ts" name="message.autotrans._Page_AdminFrameworkUserCreate;false">
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
        ITCode: '',
        Password: '',
        Name: '',
        IsValid: true,
        PhotoId: null,
        Email: '',
        Gender: undefined,
        CellPhone: '',
        HomePhone: '',
        Address: '',
        ZipCode: '',
      },

      SelectedFrameworkUserRolesIDs: [],
      SelectedFrameworkUserGroupsIDs: [],
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
            frameworkuserApi().add(stateFrameworkUser.vmModel).then(() => {
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
    
    other.getSelectList('/api/_Admin/FrameworkUser/GetFrameworkRoles',[],false).then(x=>{stateFrameworkUser.AllFrameworkUserRoles = x});
    other.getSelectList('/api/_Admin/FrameworkUser/GetFrameworkGroups?istree=true',[],true).then(x=>{stateFrameworkUser.AllFrameworkUserGroups = x});
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

