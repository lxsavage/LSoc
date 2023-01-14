import { defineStore } from 'pinia'

export const useHelloWorldStore = defineStore('helloWorld', {
    state: () => ({
        message: 'Hello world!',
        count: 0
    }),
    actions: {
        increment() {
            this.count++
        }
    }
})