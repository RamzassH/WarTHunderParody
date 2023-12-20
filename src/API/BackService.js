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
        const response = await axios.get('http://localhost:5283/Categories/GetCategories')
        return response
    }

    static async login(login, password) {
        const article = {email:login, password:password}
        console.log(article)
        const response = await axios.post('http://localhost:5283/api/Auth/login',article)
        return response;
    }

    //TODO фильтры
    static async getTechnique(limit, page) {
        const response = await axios.
        get(`http://localhost:5283/api/Product/GetTechnique?Limit=${limit}&Page=${[page]}`)
        return response
    }

    static async getPremiumAccounts(limit, page) {
        const response = await axios.
        get(`http://localhost:5283/api/Product/GetPremiumAccounts?Limit=${limit}&Page=${[page]}`)
        return response
    }

    static async getPremiumCurrency(limit, page) {
        const response = await axios.
        get(`http://localhost:5283/api/Product/GetPremiumCurrency?Limit=${limit}&Page=${[page]}`)
        return response
    }

    static async register(login, username, password) {
        const article = {email:login, name:username, password:password}
        console.log(article)
        const response = await axios.post('http://localhost:5283/api/Auth/register',article)
        return response;
    }

    static async getProduct(id) {
        const response = await  axios.post(`http://localhost:5283/api/Product/GetProduct?id=${id}`)
        return response;
    }

}