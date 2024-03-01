

import request from '/@/utils/request';
import other from '/@/utils/other';

function frameworkuserApi() {
	return {
		search: (data: object) => {
			return request({
				url: '/api/_Admin/FrameworkUser/SearchFrameworkUser',
				method: 'post',
				data,
			});
		},
		get: (data: number|string) => {
			return request({
				url: '/api/_Admin/FrameworkUser/'+data,
				method: 'get'
			});
		},
		add:(data: object)=>{
			return request({
				url:'/api/_Admin/FrameworkUser/create',
				method:'post',
				data
			});
		},
		edit:(data: object)=>{
			return request({
				url:'/api/_Admin/FrameworkUser/edit',
				method:'put',
				data
			});
		},
     	batchedit:(data: object)=>{
			return request({
				url:'/api/_Admin/FrameworkUser/batchedit',
				method:'post',
				data
			});
		},    
		delete:(data: Array<number>|Array<string>)=>{
			return request({
				url:'/api/_Admin/FrameworkUser/BatchDelete',
				method:'post',
				data
			});
		},
		export: (data: object) => {
			return request<any,Blob>({
				responseType: "blob",
				url: '/api/_Admin/FrameworkUser/FrameworkUserExportExcel',
				method: 'post',
				data,
			}).then((data)=>{other.downloadFile(data)});;
		},
		exportById: (data: Array<number>|Array<string>) => {
			return request<any,Blob>({
				responseType: "blob",
				url: '/api/_Admin/FrameworkUser/FrameworkUserExportExcelByIds',
				method: 'post',
				data,
			}).then((data)=>{other.downloadFile(data)});
		},
		import: (data: object) => {
			return request({
				url: '/api/_Admin/FrameworkUser/Import',
				method: 'post',
				data,
			});
		},
        approve: (data: object,tag:string) => {
			return request({
				url: '/api/_Admin/FrameworkUser/approve?tag='+tag,
				method: 'post',
				data
			});
		},
	};
}

export {frameworkuserApi}
