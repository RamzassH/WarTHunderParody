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
        const response = await axios.get('http://localhost:5283/GetCategories/GetCategories')
        return response
    }

    static async login(login, password, setToken) {
        const article = {email:login, password:password}
        console.log(article)
        const response = await axios.post('http://localhost:5283/api/Auth/login',article)
        setToken(response.data.token)

    }
}