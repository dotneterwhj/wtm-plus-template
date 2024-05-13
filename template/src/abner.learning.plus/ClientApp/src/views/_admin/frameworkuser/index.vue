
<template>
<div class="card-fill layout-padding">
<el-card shadow="hover" class="layout-padding-auto" >
  <WtmSearcher v-model="searchDataFrameworkUser" @search="getTableDataFrameworkUser">
      <el-row>
        <el-col :xs="24" :lg="8" class="mb20">
        <el-form-item ref="ITCode_FormItem" prop="ITCode" :label="$t('message.autotrans._Model_FrameworkUser_ITCode')">
            <el-input v-model="searchDataFrameworkUser.ITCode" clearable></el-input>
        </el-form-item>

        </el-col>
        <el-col :xs="24" :lg="8" class="mb20">
        <el-form-item ref="Name_FormItem" prop="Name" :label="$t('message.autotrans._Model_FrameworkUser_Name')">
            <el-input v-model="searchDataFrameworkUser.Name" clearable></el-input>
        </el-form-item>

        </el-col>
        <el-col :xs="24" :lg="8" class="mb20">
        <el-form-item ref="IsValid_FormItem" prop="IsValid" :label="$t('message.autotrans._Model_FrameworkUser_IsValid')">
            <el-select v-model="searchDataFrameworkUser.IsValid" clearable>
               <el-option :key="1" :value=true :label="$t('message._system.common.vm.tips_bool_true')"></el-option>
               <el-option :key="0" :value=false :label="$t('message._system.common.vm.tips_bool_false')"></el-option>
            </el-select>
        </el-form-item>

        </el-col>
      </el-row>

  </WtmSearcher>

  <div style="text-align: right;">
      <WtmButton v-auth="'/api/_Admin/FrameworkUser/Create'" icon='fa fa-plus' type='primary' :button-text="$t('message.autotrans.SysCreate')" @click="OnCreateClick()"/>
    <WtmButton v-auth="'/api/_Admin/FrameworkUser/Import'" icon='fa fa-tasks' type='primary' :button-text="$t('message.autotrans.SysImport')" @click="OnImportClick()"/>
    <WtmButton v-auth="'/api/_Admin/FrameworkUser/BatchDelete'"  icon='fa fa-trash' type='danger' :button-text="$t('message.autotrans.SysDelete')" :confirm="$t('message._system.common.vm.deletetip')" @click="onBatchDelete()"/>
    <WtmButton v-auth="'/api/_Admin/FrameworkUser/BatchEdit'" icon='fa fa-pencil-square' type='primary' :button-text="$t('message.autotrans.SysBatchEdit')" @click="OnBatchEditClick()"/>
    <WtmButton v-auth="'/api/_Admin/FrameworkUser/FrameworkUserExportExcel'"  icon='fa fa-arrow-circle-down' type='primary' :button-text="$t('message.autotrans.SysExport')" @click="onExport()"/>

  </div>
  <WtmTable ref="tableRefFrameworkUser" v-bind="tableDataFrameworkUser">
    <template #operation>
      <el-table-column :label="$t('message._system.common.vm.operate')" width="240">
        <template v-slot="scope">
            <WtmButton v-auth="'/api/_Admin/FrameworkUser/Edit'" :is-text="true" icon='fa fa-pencil-square' type='warning' :button-text="$t('message.autotrans.SysEdit')" @click="OnEditrowClick(scope.row)"/>
          <WtmButton v-auth="'/api/_Admin/FrameworkUser/{id}'" :is-text="true" icon='fa fa-info-circle' type='info' :button-text="$t('message.autotrans.Page详情')" @click="OnDetailsrowClick(scope.row)"/>
          <WtmButton v-auth="'/api/_Admin/FrameworkUser/BatchDelete'"  icon='fa fa-trash' type='danger' :button-text="$t('message.autotrans.SysDelete')" :confirm="$t('message._system.common.vm.deletetip')" :is-text="true"  @click="onDelete(scope.row)"/>
          <WtmButton v-auth="'/api/_Admin/FrameworkUser/Edit'" :is-text="true" icon='fa fa-unlock-alt' type='warning' :button-text="$t('message.autotrans.LoginChangePassword')" @click="OnPasswordrowClick(scope.row)"/>

        </template>
      </el-table-column>
    </template>
  </WtmTable>

</el-card>
</div>
</template>


<script setup lang="ts" name="message.autotrans._Page_AdminFrameworkUserIndex;true;Abner.Learning.Plus._Admin.Controllers;FrameworkUser">
import {  ElMessageBox, ElMessage,ElLoading } from 'element-plus';
import { defineAsyncComponent,reactive, ref, getCurrentInstance, onMounted, nextTick } from 'vue';
import { frameworkuserApi } from '/@/api/_admin/frameworkuser';
import other from '/@/utils/other';
import fileApi from '/@/api/file';
import { useRouter } from "vue-router";
const ci = getCurrentInstance() as any;

const CreateDialog = defineAsyncComponent(() => import('./create.vue'));
const EditDialog = defineAsyncComponent(() => import('./edit.vue'));
const DetailsDialog = defineAsyncComponent(() => import('./details.vue'));
const ImportDialog = defineAsyncComponent(() => import('./import.vue'));
const BatchEditDialog = defineAsyncComponent(() => import('./batchedit.vue'));
const PasswordDialog = defineAsyncComponent(() => import('./password.vue'));

const stateFrameworkUser = reactive({
    
});

const searchDataFrameworkUser = ref({
        ITCode: '',
        Name: '',
        IsValid: undefined,
});

// 定义变量内容
const tableRefFrameworkUser = ref();
const tableDataFrameworkUser = ref({
    // 列表数据（必传）
    data: [],
	// 表头内容（必传，注意格式）
	header: [
      {title:ci.proxy.$t('message.autotrans.SysAccount'),key: 'FrameworkUser_ITCode',type: 'text',isCheck: true},
      {title:ci.proxy.$t('message.autotrans._AdminName'),key: 'FrameworkUser_Name',type: 'text',isCheck: true},
      {title:ci.proxy.$t('message.autotrans._AdminGender'),key: 'FrameworkUser_Gender',type: 'text',isCheck: true},
      {title:ci.proxy.$t('message.autotrans._AdminCellPhone'),key: 'FrameworkUser_CellPhone',type: 'text',isCheck: true},
      {title:ci.proxy.$t('message.autotrans._AdminRole'),key: 'FrameworkUser_Role',type: 'text',isCheck: true},
      {title:ci.proxy.$t('message.autotrans._AdminGroup'),key: 'FrameworkUser_Group',type: 'text',isCheck: true},
      {title:ci.proxy.$t('message.autotrans._AdminIsValid'),key: 'FrameworkUser_IsValid',type: 'switch',isCheck: true},
      {title:ci.proxy.$t('message.autotrans._AdminPhoto'),key: 'FrameworkUser_Photo',type: 'image',imageWidth: '70', imageHeight: '40',isCheck: true},

	],
	// 配置项（必传）
	config: {
        total: 0, // 列表总数
		loading: true, // loading 加载
		isSerialNo: true, // 是否显示表格序号
		isSelection: true, // 是否显示表格多选
		isOperate: true, // 是否显示表格操作栏
	}
});
// 初始化表格数据
const getTableDataFrameworkUser = () => {
    tableRefFrameworkUser.value.doSearch(frameworkuserApi().search, searchDataFrameworkUser.value)
        .catch((error: any) => {
			other.setFormError(ci, error);
		});
};
const OnCreateClick = () => {
    other.openDialog(ci.proxy.$t('message.autotrans.SysCreate'), CreateDialog, null, getTableDataFrameworkUser)
};

const OnEditrowClick = (row: any) => {
    other.openDialog(ci.proxy.$t('message.autotrans.SysEdit'), EditDialog, row, getTableDataFrameworkUser)
};

const OnDetailsrowClick = (row: any) => {
    other.openDialog(ci.proxy.$t('message.autotrans.Page详情'), DetailsDialog, row, getTableDataFrameworkUser)
};

const OnImportClick = () => {
    other.openDialog(ci.proxy.$t('message.autotrans.SysImport'), ImportDialog, null, getTableDataFrameworkUser)
};

// 删除
const onDelete = (row: any) => {
    frameworkuserApi().delete([row.ID]).then(() => { getTableDataFrameworkUser()})
};

const onBatchDelete = () => {
    const selectedrows = tableRefFrameworkUser.value.getSelectedRows();
    const selectedids = selectedrows.map((x: any) => x.ID);
    if (selectedids.length > 0)
      frameworkuserApi().delete(selectedids).then(() => { getTableDataFrameworkUser()})
    else
      ElMessage.error(ci.proxy.$t('message._system.common.vm.check'));
};

const OnBatchEditClick = () => {
    const selectedrows = tableRefFrameworkUser.value.getSelectedRows();
    const selectedids = selectedrows.map((x: any) => x.ID);
    if (selectedids.length > 0)
      other.openDialog(ci.proxy.$t('message.autotrans.SysBatchEdit'), BatchEditDialog, selectedids, getTableDataFrameworkUser)
    else
      ElMessage.error(ci.proxy.$t('message._system.common.vm.check'));
};

const onExport = () => {
	const selected = tableRefFrameworkUser.value.getSelectedRows();
	if (selected.length > 0) {
		frameworkuserApi().exportById(selected.map((x: any) => x.ID));
	}
	else {
		frameworkuserApi().export({});
	}
};

const OnPasswordrowClick = (row: any) => {
    other.openDialog(ci.proxy.$t('message.autotrans.LoginChangePassword'), PasswordDialog, row, getTableDataFrameworkUser)
};

// 页面加载时
onMounted(() => {
    
        getTableDataFrameworkUser();

});

// 暴露变量
defineExpose({

});
</script>

<style scoped lang="scss">

</style>

