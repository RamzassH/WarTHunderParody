import React, {useContext, useEffect, useState} from 'react';
import LoginModal from "./UI/LoginModal/LoginModal";
import LoginForm from "./UI/LoginForm/LoginForm";
import CreateModal from "./UI/CreateModal/CreateModal";
import CreateForm from "./UI/CreateForm/CreateForm";
import {useFetching} from "../hooks/useFetching";
import BackService from "../API/BackService";
import {AuthContext} from "../context";
import {jwtDecode} from "jwt-decode";

const LoginCreateComponent = ({modalLogin, setModalLogin, modalCreateUser, setModalCreateUser, setIsAuth, setToken, token}) => {
    const {setIsReloadData, setUserInfoFromToken} = useContext(AuthContext)
    const [getToken, isLoading, tokenError] = useFetching(async (userData) => {
        const response = await BackService.login(userData.login, userData.password)
        setToken({token:response.data.token, username:response.data.name})
    })
    const [register, isRegistration, errorRegistration] = useFetching(async (data) => {
        const response = await BackService.register(data.login, data.username, data.password)
    })

    const [startRegistration, setStart] = useState(false)



    useEffect(() => {
        if (token.token) {
            setIsAuth(true)
            localStorage.setItem('auth', 'true')
            localStorage.setItem('token', token.token)
            localStorage.setItem('username', token.username)
            setModalLogin(false)
            setUserInfoFromToken(jwtDecode(token.token))
        }

    }, [token]);

    function loginUser(userData) {
        getToken(userData)
        if (!userData.login || !userData.password) {
            throw "Поля Логин и Пароль не должны быть пусты"
        }

    }


    function createUser(userData) {
        if (!userData.username ||
            !userData.login ||
            !userData.password) {
            throw "Все поля должны быть заполнены"
        }
        if (userData.password.localeCompare(userData.repeatPassword)) {
            throw "Пароль, введённый повторно, не совпадает с первым"
        }

        console.log(userData)
        register(userData)
        // setStart(true);
        setModalCreateUser(false)
    }

    return (
        <div>
            <LoginModal visible={modalLogin} setVisible={setModalLogin}>
                {!isLoading?
                    <LoginForm login={loginUser} create={() => {setModalLogin(false); setModalCreateUser(true)}}/>
                    :
                    null
                }
            </LoginModal>
            <CreateModal visible={modalCreateUser} setVisible={setModalCreateUser}>
                {!isRegistration?
                    <CreateForm create={createUser}/>
                    :
                    null
                }
            </CreateModal>
        </div>
    );
};

export default LoginCreateComponent;