import { useGameStore } from '@/stores/gameStore'

const gameStore = useGameStore();

export default defineNuxtRouteMiddleware((to, from) => {
	if (!gameStore.$state.game.gameId) {
		return navigateTo('/')
	}
})