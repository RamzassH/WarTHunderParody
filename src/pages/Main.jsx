import React, {useContext, useEffect, useState} from 'react';
import Background from "../components/UI/Background/Background";
import Menu from "../components/UI/Menu/Menu";
import MenuItem from "../components/UI/MenuItem/MenuItem";
import Nav from "../components/UI/Nav/Nav";
import NavItem from "../components/UI/NavItem/NavItem";
import Section from "../components/UI/Section/Section";
import ListWidget from "../components/UI/ListWidget/ListWidget";
import Widget from "../components/UI/Widget/Widget";
import LoginModal from "../components/UI/LoginModal/LoginModal";
import LoginForm from "../components/UI/LoginForm/LoginForm";
import {useFetching} from "../hooks/useFetching";
import PostService from "../API/PostService";
import {getPageCount} from "../utils/pages";
import BackService from "../API/BackService";
import CreateModal from "../components/UI/CreateModal/CreateModal";
import CreateForm from "../components/UI/CreateForm/CreateForm";
import {useNavigate} from "react-router-dom";
import MenuItemProfile from "../components/UI/MenuItemProfile/MenuItemProfile";
import {AuthContext} from "../context";
import LoginCreateComponent from "../components/LoginCreateComponent";

const Main = () => {
    const {isAuth, setIsAuth, token, setToken} = useContext(AuthContext)
    let navigate = useNavigate()
    const [modalLogin, setModalLogin] = useState(false)
    const [modalCreateUser, setModalCreateUser] = useState(false)
    const [categories, setCategories] = useState([])
    /*
    const [getToken, isLoading, tokenError] = useFetching(async (userData) => {
        await BackService.login(userData.login, userData.password, setToken)

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
    */
    function Exit(functionIsAuth, functionToken) {
        localStorage.setItem("auth", 'false');
        localStorage.setItem("token", "");
        localStorage.setItem("username", "")
        functionIsAuth(false);
        functionToken({token: "", username: ""});
    }

    return (
        <div style={{
            display: "flex",
            width: "100%",
            flexDirection: 'column',
            alignItems: 'center',
        }}>
            <Background></Background>

            <Menu>
                <MenuItem>
                    L
                </MenuItem>
                <MenuItem>
                    Игры
                </MenuItem>
                <MenuItem>
                    Магазин
                </MenuItem>
                <MenuItem style={{marginRight: "auto"}}>
                    Поддержка
                </MenuItem>

                {!isAuth
                    ?
                    <MenuItem
                        onClick={() => setModalLogin(true)}
                        style={{color: "#ffe8aa"}}
                    >
                        Войти
                    </MenuItem>
                    :
                    <MenuItemProfile
                        profileFunction={() => {
                            navigate('/profile')
                        }}
                        exitFunction={() => {
                            Exit(setIsAuth, setToken);
                            navigate('/')
                        }}
                        username={token.username}
                    />
                }
                <MenuItem>
                    Ru
                </MenuItem>
            </Menu>

            <LoginCreateComponent
                modalLogin={modalLogin}
                setModalLogin={setModalLogin}
                modalCreateUser={modalCreateUser}
                setModalCreateUser={setModalCreateUser}
                setIsAuth={setIsAuth}
                setToken={setToken}
                token={token}
            />

            <Nav>
                <NavItem onClick={() => navigate("/")}>
                    H
                </NavItem>
                <NavItem onClick={() => navigate("/premium_currency")}>
                    Золотые Орлы
                </NavItem>
                <NavItem onClick={() => navigate("/technic")}>
                    Техника
                </NavItem>
                <NavItem onClick={() => navigate("/premium_account")}>
                    Премиум аккаунт
                </NavItem>
                <NavItem>
                    Саундтрек
                </NavItem>
                <NavItem>
                    Бонус-код
                </NavItem>
            </Nav>

            <Section>
                <div className="main-offer__showcase">
                    <div style={{
                        width: "calc(100% - 390px)",
                        height: "auto",
                    }}>
                        <img
                            src="https://images-live.warthunder.com/f68/01d/db8ac0b61abe581ae5cffa4ca5d722a7f5.jpeg"
                            style={{
                                height: "440px",
                                width: "auto",
                            }}
                        />
                    </div>
                </div>

                <ListWidget>
                    <Widget
                        onClick={() => navigate("/technic")}
                        src="https://static-store.gaijin.net/templates/shop/assets/img/jpg/Categories/wt_packs.jpg"
                        style={{
                            marginBottom: "24px"
                        }}
                    >
                        Техника
                    </Widget>
                    <Widget
                        onClick={() => navigate("/premium_currency")}
                        src="https://static-store.gaijin.net/templates/shop/assets/img/jpg/Categories/wt_golden_eagles.jpg"
                        style={{
                            marginBottom: "0",
                            marginRight: "24px",
                            width: "calc(50% - 12px)",
                        }}
                    >
                        Золотые орлы
                    </Widget>
                    <Widget
                        onClick={() => navigate("/premium_account")}
                        src="https://static-store.gaijin.net/templates/shop/assets/img/jpg/Categories/wt_premium.jpg"
                        style={{
                            marginBottom: "0",
                            width: "calc(50% - 12px)",
                        }}
                    >
                        Премиум аккаунт
                    </Widget>
                </ListWidget>
            </Section>

        </div>
    );
};

export default Main;