<template>
	<div style="height:100%">
		<component :is="isEmpty? emptyLayout : layouts[themeConfig.layout]" />
		<iframe v-for="(v,k) in urls" :key="k" :src="v" height="0" frameborder="0" />
	</div>
</template>

<script setup lang="ts" name="layout">
    import { onBeforeMount, onUnmounted, defineAsyncComponent, ref, reactive, onMounted, nextTick } from 'vue';
	import { storeToRefs } from 'pinia';
	import { useThemeConfig } from '/@/stores/themeConfig';
    import { Session,Local } from '/@/utils/storage';
	import mittBus from '/@/utils/mitt';
	import { useRouter } from "vue-router";
	import  loginapi from '/@/api/login'
	import { useUserInfo } from '/@/stores/userInfo';

    const state = reactive({
        setIntervalTime: 0,
    });

	const urls = ref<string[]>()
	const isEmpty = ref(false)
	// 引入组件
	const layouts: any = {
		defaults: defineAsyncComponent(() => import('/@/layout/main/defaults.vue')),
		classic: defineAsyncComponent(() => import('/@/layout/main/classic.vue')),
		transverse: defineAsyncComponent(() => import('/@/layout/main/transverse.vue')),
		columns: defineAsyncComponent(() => import('/@/layout/main/columns.vue')),
	};

	const emptyLayout = defineAsyncComponent(() => import('/@/layout/main/empty.vue'))
	// 定义变量内容
	const storesThemeConfig = useThemeConfig();
	const { themeConfig } = storeToRefs(storesThemeConfig);

	// 窗口大小改变时(适配移动端)
	const onLayoutResize = () => {
		if (!Local.get('oldLayout')) Local.set('oldLayout', themeConfig.value.layout);
		const clientWidth = document.body.clientWidth;
		if (clientWidth < 1000) {
			themeConfig.value.isCollapse = false;
			mittBus.emit('layoutMobileResize', {
				layout: 'defaults',
				clientWidth,
			});
		} else {
			mittBus.emit('layoutMobileResize', {
				layout: Local.get('oldLayout') ? Local.get('oldLayout') : themeConfig.value.layout,
				clientWidth,
			});
		}
	};

	const refreshToken = () => {
		loginapi().refreshToken().then(async res => {
			Local.set('token', res.access_token);
            const userInfos: any = await useUserInfo().getApiUserInfo();
			if (userInfos) {
				Session.set('userInfo', userInfos);
				await useUserInfo().setUserInfos();
			}		

        }).catch(() => {
        })
	}

	// 页面加载前
	onBeforeMount(() => {
		if (useRouter().currentRoute.value.query._nomenu) {
			isEmpty.value = true;
		}
		else {			
			refreshToken();
		}
		onLayoutResize();
		window.addEventListener('resize', onLayoutResize);
	});
	onMounted(() => {
        state.setIntervalTime = window.setInterval(() => {
            refreshToken();
        }, 1800000);
	});
	// 页面卸载时
	onUnmounted(() => {
		window.removeEventListener('resize', onLayoutResize);
        window.clearInterval(state.setIntervalTime);
	});
</script>
