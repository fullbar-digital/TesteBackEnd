import axios from 'axios'
import { eventBus } from './eventbus'

export default (Vue, router) => {

  const service = axios.create({
    baseURL: process.env.VUE_APP_BASE_API_URL
  });
  
  service.interceptors.response.use(
    response => {
      eventBus.$emit('onResponse')
      return response
    },
    error => {         
      eventBus.$emit('onResponseError', error)
  
      switch (error.response.status) {
        case 401:
          localStorage.clear()
          router.push('/home')  
          return

        case 403:
          router.push('/403')
          return

        default:     
          return Promise.reject(error)
      }
    }
  )
  
  Vue.prototype.$request = service
}