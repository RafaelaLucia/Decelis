import axios from 'axios';

const api = axios.create({
    baseURL: 'https://decelis.herokuapp.com/api',
});

export default api;