// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  ssr: true,
  devtools: { enabled: true },

  runtimeConfig: {
    public: {
      API_ENDPOINT_BASE: process.env.API_ENDPOINT_BASE,
    },
  },
  
  vite: {
		css: {
			preprocessorOptions: {
				scss: {
					api: 'modern-compiler',
					additionalData: `
						@use "@/assets/styles/global.scss";
						`
				},
			},
		},
	},

  modules: ['@pinia/nuxt'],
  compatibilityDate: '2024-10-22'
})