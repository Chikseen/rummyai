<template>
  <NuxtLayout>
    <NuxtPage />
  </NuxtLayout>
</template>

<script lang="ts">
import { initHub } from '~/services/hubs/gameHub';

export default {
  async mounted() {
    await initHub();
  },
}
</script>