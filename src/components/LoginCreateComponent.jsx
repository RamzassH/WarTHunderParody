import React from 'react';
import LoginModal from "./UI/LoginModal/LoginModal";
import LoginForm from "./UI/LoginForm/LoginForm";
import CreateModal from "./UI/CreateModal/CreateModal";
import CreateForm from "./UI/CreateForm/CreateForm";
import {useFetching} from "../hooks/useFetching";
import BackService from "../API/BackService";

const LoginCreateComponent = ({modalLogin, setModalLogin, modalCreateUser, setModalCreateUser, setIsAuth, setToken}) => {
    const [getToken, isLoading, tokenError] = useFetching(async (userData) => {
        const response = await BackService.login(userData.login, userData.password)
        setToken(response.data)
    })
    const [register, IsRegistration, errorRegistration] = useFetching(async (data) => {
        const response = await BackService.register(data.login, data.username, data.password)
    })

    function loginUser(userData) {
        //getToken(userData)
        if (!userData.login || !userData.password) {
            throw "Поля Логин и Пароль не должны быть пусты"
        }

        setIsAuth(true)
        localStorage.setItem('auth', 'true')
        setModalLogin(false)
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
        setModalCreateUser(false)
    }

    return (
        <div>
            <LoginModal visible={modalLogin} setVisible={setModalLogin}>
                <LoginForm login={loginUser} create={() => {setModalLogin(false); setModalCreateUser(true)}}/>
            </LoginModal>
            <CreateModal visible={modalCreateUser} setVisible={setModalCreateUser}>
                <CreateForm create={createUser}/>
            </CreateModal>
        </div>
    );
};

export default LoginCreateComponent;