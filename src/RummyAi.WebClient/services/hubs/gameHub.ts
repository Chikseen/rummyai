import * as signalR from "@microsoft/signalr";
import { useGameStore } from '@/stores/gameStore'
import { useConnectionStore } from "~/stores/connectionStore";
import type { Game } from "~/domain/models/Game";
import { createPinia } from 'pinia'
import { createApp } from 'vue'
import App from '~/app.vue'

export async function initHub() {
	const pinia = createPinia()
	const app = createApp(App)
	var config = useRuntimeConfig()

	const gameStore = useGameStore();
	const connectionStore = useConnectionStore();

	app.use(pinia)

	const connection = new signalR.HubConnectionBuilder()
		.withUrl(`${config.public.API_ENDPOINT_BASE}/gamehub`, {
			withCredentials: false,
		})
		.withAutomaticReconnect()
		.build();

	await connection.start().catch((err) => document.write(err));

	connectionStore.$state.connection = connection;

	connection.on("SendNewGameStateToGameId", (game: Game,) => {
		gameStore.setGame(game);
	});
}