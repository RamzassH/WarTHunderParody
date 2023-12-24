import React, {useEffect, useState} from 'react';
import './styles/App.css';
import {AuthContext} from "./context";
import {BrowserRouter} from "react-router-dom";
import AppRouter from "./components/AppRouter";
import {jwtDecode} from 'jwt-decode'

function App() {
    const [isAuth, setIsAuth] = useState(false);
    const [isLoading, setLoading] = useState(true);
    const [token, setToken] = useState({token:"", username:""});
    const [isReloadData, setIsReloadData] = useState(false)
    const [userInfoFromToken, setUserInfoFromToken] = useState({});


    useEffect(() => {
        if (localStorage.getItem("auth")) {
            if (!localStorage.getItem('auth').localeCompare('true')) {
                setIsAuth(true)
                if (localStorage.getItem("token") && localStorage.getItem("username")) {
                    setToken({token: localStorage.getItem("token"),
                        username: localStorage.getItem("username")})
                    setUserInfoFromToken(jwtDecode(localStorage.getItem("token")))

                }
            } else if (localStorage.getItem('auth').localeCompare('false')) {
                setIsAuth(false)
            }
        }

        setLoading(false);
    }, [isReloadData])



    return (
        <AuthContext.Provider value={{
            isAuth,
            setIsAuth,
            isLoading,
            token,
            setToken,
            userInfoFromToken,
            setUserInfoFromToken,
            setIsReloadData
        }}>
            <BrowserRouter>
                <AppRouter/>
            </BrowserRouter>
        </AuthContext.Provider>
    )

}

export default App;
