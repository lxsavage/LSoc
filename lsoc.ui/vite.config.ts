import { defineConfig } from "vite";
import vue from "@vitejs/plugin-vue";

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [vue()],
  server: {
    port: 8080,
    open: true,
    proxy: {
      "/api": {
        target: "http://localhost:5017",
        changeOrigin: true,
        secure: false,
        ws: true
      }
    }
  }
});
