<template>

                        <el-timeline>
                            <el-timeline-item v-for="(activity, index) in localdata.approveRecords"
                                              :key="index" placement="top"
                                              :color="getColor(activity)"
                                              :timestamp="activity.Time">
                                {{ activity.Message }}
                                <p v-if="activity.Remark">审批意见：{{activity.Remark}}</p>
                            </el-timeline-item>
                        </el-timeline>
</template>


<script setup lang="ts">
import { watch, reactive, ref, getCurrentInstance, onMounted, nextTick } from 'vue';
import other from '/@/utils/other';
import loginapi from '/@/api/login';
const ci = getCurrentInstance() as any;

    const props = defineProps({
        flowname: String,
        entitytype: String,
        entityid: null,
    });
// 定义变量内容
const localdata = reactive({
    approveRecords: [] as any[]
});
  

    watch(()=>props.entityid, () => {
        if (props.entityid) {
            loginapi().getTimeLine(props.flowname ?? "", props.entitytype ?? "", props.entityid ?? "")
                .then((data: any) => {
                    localdata.approveRecords = data;
                })
        }
    })

    const getColor = (data : any)=>{
        if (data.Action == '同意') {
            return "#0bbd87";
        }
        if (data.Action == '拒绝') {
            return "#ff0000";
        }
        return "";
    }
// 暴露变量
defineExpose({

});
</script>

<style scoped lang="scss">

</style>

