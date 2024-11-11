<template>
  <NuxtLayout>
    <NuxtPage />
  </NuxtLayout>
</template>

<script lang="ts">
import { initHub } from '~/services/hubs/gameHub';

export default {
  data() {
    return {
      gameStore: useGameStore(),
    }
  },
  async mounted() {
    await initHub();
    this.gameStore.setPlayerId();
  },
}
</script>