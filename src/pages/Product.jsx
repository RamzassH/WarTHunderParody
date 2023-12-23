import React, {useContext, useEffect, useState} from 'react';
import {useNavigate, useParams} from "react-router-dom";
import Background from "../components/UI/Background/Background";
import Menu from "../components/UI/Menu/Menu";
import MenuItem from "../components/UI/MenuItem/MenuItem";
import LoginModal from "../components/UI/LoginModal/LoginModal";
import LoginForm from "../components/UI/LoginForm/LoginForm";
import CreateModal from "../components/UI/CreateModal/CreateModal";
import CreateForm from "../components/UI/CreateForm/CreateForm";
import Nav from "../components/UI/Nav/Nav";
import NavItem from "../components/UI/NavItem/NavItem";
import {useFetching} from "../hooks/useFetching";
import BackService from "../API/BackService";
import ProductForm from "../components/UI/ProductForm/ProductForm";
import {AuthContext} from "../context";
import MenuItemProfile from "../components/UI/MenuItemProfile/MenuItemProfile";
import LoginCreateComponent from "../components/LoginCreateComponent";

const Product = () => {
    const params = useParams()
    const {isAuth, setIsAuth} = useContext(AuthContext)

    let isTechnic = false;
    let isPremiumCurrency = false;
    let isPremiumAccount = false;
    if (!params.category.localeCompare("technic")) {
        isTechnic = true;
    }
    if (!params.category.localeCompare("premium_account")) {
        isPremiumAccount = true;
    }
    if (!params.category.localeCompare("premium_currency")) {
        isPremiumCurrency = true;
    }

    let title = 'dada id = ' + params.id

    const [modalLogin, setModalLogin] = useState(false)
    const [modalCreateUser, setModalCreateUser] = useState(false)
    const [data, setData] = useState({title:'', image:'', description:'', price: 0})
    const [token, setToken] = useState("");
    /*
    const [getToken, isLoading, tokenError] = useFetching(async (userData) => {
        await BackService.login(userData.login, userData.password, setToken)
    })
    const [register, IsRegistration, errorRegistration] = useFetching(async (data) => {
        const response = await BackService.register(data.login, data.username, data.password)
    })
    */
    const [getProduct, isLoadingProduct, errorProduct] = useFetching(async () => {
        const response = await BackService.getProduct(params.id)
        setData({
            title: response.data.name,
            image: response.data.image,
            description: response.data.description,
            price: response.data.price
        })
        // setData({
        //     title: "Титульник",
        //     image: "https://static-store.gaijin.net/img/screenshots/6673008D-A324-48CF-869A-2A67E9F7656A/big/1.jpg",
        //     description: "Описание",
        //     price: "1000 у.е."
        // })
    })
    let navigate = useNavigate()

    useEffect(() => {
        getProduct()
    }, []);
    /*
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
    const buy = () => {
        if (isAuth) {
            navigate(`/buy/${params.id}`)
        } else {
            setModalLogin(true)
        }
    }

    return (
        <div
            style={{
                    display: "flex",
                    width: "100%",
                    flexDirection: 'column',
                    alignItems: 'center',
            }}
        >
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
                        profileFunction={() => {navigate('/profile')}}
                        exitFunction={() => {setIsAuth(false); localStorage.setItem('auth', 'false'); navigate('/')}}
                        username="TiltMan"
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
            />

            <Nav>
                <NavItem onClick={() => navigate("/")}>
                    H
                </NavItem >
                <NavItem
                    onClick={() => {navigate("/premium_currency");}}
                    isActiveItem={isPremiumCurrency}
                >
                    Золотые Орлы
                </NavItem>
                <NavItem
                    onClick={() => {navigate("/technic");}}
                    isActiveItem={isTechnic}
                >
                    Техника
                </NavItem>
                <NavItem
                    onClick={() => {navigate("/premium_account");}}
                    isActiveItem={isPremiumAccount}
                >
                    Премиум аккаунт
                </NavItem>
                <NavItem>
                    Саундтрек
                </NavItem>
                <NavItem>
                    Бонус-код
                </NavItem>
            </Nav>

            <ProductForm
                title={data.title}
                image={data.image}
                description={data.description}
                price={data.price}
                buyFunction={buy}
            />

        </div>
    );
};

export default Product;