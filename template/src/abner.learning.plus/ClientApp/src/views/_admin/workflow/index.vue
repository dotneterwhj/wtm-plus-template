
<template>
    <div class="card-fill layout-padding">
            <iframe :src="url" frameborder="0" style="height:100%;height:100%" />
        </div>
</template>


<script setup lang="ts" name="message._system.menukey.Workflow;true;">
import {  ElMessageBox, ElMessage } from 'element-plus';
import { defineAsyncComponent,reactive, ref, getCurrentInstance, onMounted, nextTick } from 'vue';
import other from '/@/utils/other';
import { Local, Session } from '/@/utils/storage';

    const url = import.meta.env.VITE_API_URL + '/_workflow/inner?access_token=' + Local.get('token')

// 暴露变量
defineExpose({

});
</script>

<style scoped lang="scss">

</style>

