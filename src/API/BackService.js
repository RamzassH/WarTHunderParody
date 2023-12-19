import axios from "axios";


export default class BackService {
    static async getAll(limit = 10, page = 1) {
        const response = await axios.get('dada', {
            params: {
                _limit: limit,
                _page: page
            }
        })
        return response;
    }

    static async getCategory() {
        const response = await axios.get('https://aed1-62-76-92-39.ngrok-free.app/Categories/GetCategories')
        return response
    }

    static async login(login, password) {
        const article = {email:login, password:password}
        console.log(article)
        const response = await axios.post('http://localhost:5283/api/Auth/login',article)
        return response;
    }

    static async getTechnic(limit, page) {
        const response = await axios.get(`https://aed1-62-76-92-39.ngrok-free.app/api/Product/GetTechnique?Limit=10&Page=1`)
        return response
    }
}