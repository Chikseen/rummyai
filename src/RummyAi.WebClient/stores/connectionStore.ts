import type { HubConnection } from '@microsoft/signalr';
import { defineStore } from 'pinia'

export const useConnectionStore = defineStore('connectionStore', {
	state: () => (
		{
			connection: {} as HubConnection
		}
	),
	getters: {
		getConnectionId(): string {
			return this.connection.connectionId?.toString() ?? '';
		}
	}
})