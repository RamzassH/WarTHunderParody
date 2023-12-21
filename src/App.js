import React, {useEffect, useState} from 'react';
import './styles/App.css';
import {AuthContext} from "./context";
import {BrowserRouter} from "react-router-dom";
import AppRouter from "./components/AppRouter";


function App() {
    const [isAuth, setIsAuth] = useState(false);
    const [isLoading, setLoading] = useState(true);
    const [token, setToken] = useState('')

    useEffect(() => {
        if (!localStorage.getItem('auth').localeCompare('true')) {
            setIsAuth(true)
        } else if (localStorage.getItem('auth').localeCompare('false')) {
            setIsAuth(false)
        }
        setLoading(false);
    }, [])



    return (
        <AuthContext.Provider value={{
            isAuth,
            setIsAuth,
            isLoading,
            token,
            setToken
        }}>
            <BrowserRouter>
                <AppRouter/>
            </BrowserRouter>
        </AuthContext.Provider>
    )

}

export default App;
