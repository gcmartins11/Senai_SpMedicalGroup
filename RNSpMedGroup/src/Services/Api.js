import Axios from 'axios'


const api = Axios.create({
    baseURL: 'https://spmedgroup.azurewebsites.net/api'
})

export default api