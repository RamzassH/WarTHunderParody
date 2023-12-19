import React, {useEffect, useState} from 'react';
import Background from "../components/UI/Background/Background";
import MenuItem from "../components/UI/MenuItem/MenuItem";
import Menu from "../components/UI/Menu/Menu";
import {useFetching} from "../hooks/useFetching";
import BackService from "../API/BackService";
import LoginModal from "../components/UI/LoginModal/LoginModal";
import LoginForm from "../components/UI/LoginForm/LoginForm";
import CreateModal from "../components/UI/CreateModal/CreateModal";
import CreateForm from "../components/UI/CreateForm/CreateForm";
import {useNavigate} from "react-router-dom";
import Nav from "../components/UI/Nav/Nav";
import NavItem from "../components/UI/NavItem/NavItem";
import Filter from "../components/UI/Filter/Filter";
import FilterLeft from "../components/UI/FilterLeft/FilterLeft";
import FilterSelect from "../components/UI/FilterSelect/FilterSelect";
import FilterSelectItem from "../components/UI/FilterSelectItem/FilterSelectItem";
import iconClasses from "../components/UI/FilterSelectItem/FilterSelectItem.module.css"
import iconNation from "../styles/NationIcon.module.css"
import Showcase from "../components/UI/Showcase/Showcase";
import ShowcaseItem from "../components/UI/ShowcaseItem/ShowcaseItem";

const Store = ({isTechnic = false, isPremiumCurrency = false, isPremiumAccount = false}) => {
    const technicCategory = [
        {name: "Танки", icon: iconClasses.Tanks, value: false},
        {name: "Авиация", icon: iconClasses.Air, value: false},
        {name: "Флот", icon: iconClasses.Navy, value: false},
        {name: "Вертолёты", icon: iconClasses.Helicopters, value: false}
    ]
    const nationCategory = [
        {name: "СССР", icon: iconNation.USSR, value: false},
        {name: "Германия", icon: iconNation.Germany, value: false},
        {name: "Пендосия", icon: iconNation.USA, value: false},
        {name: "Великобритания", icon: iconNation.GreatBritain, value: false},
        {name: "Япония", icon: iconNation.Japan, value: false},
        {name: "Италия", icon: iconNation.Italy, value: false},
        {name: "Франция", icon: iconNation.France, value: false},
        {name: "Китай", icon: iconNation.China, value: false},
        {name: "Шведция", icon: iconNation.Sweden, value: false},
        {name: "Моиши", icon: iconNation.Israel, value: false},
    ]

    let filterTechnicValue = [
        {name: "Танки", value: false},
        {name: "Авиация", value: false},
        {name: "Флот", value: false},
        {name: "Вертолёты", value: false}
    ]
    let filterNationValue = [
        {name: "СССР", value: false},
        {name: "Германия", value: false},
        {name: "Пендосия", value: false},
        {name: "Великобритания", value: false},
        {name: "Япония", value: false},
        {name: "Италия", value: false},
        {name: "Франция", value: false},
        {name: "Китай", value: false},
        {name: "Шведция", value: false},
        {name: "Моиши", value: false}
    ]

    let navigate = useNavigate()
    const [modalLogin, setModalLogin] = useState(false)
    const [modalCreateUser, setModalCreateUser] = useState(false)
    const [categories, setCategories] = useState([])
    const [token, setToken] = useState("");
    const [fetchCategories, isPostsLoading, postError] = useFetching(async () => {
        const response = await BackService.getCategory();
        console.log(response.data)
        setCategories([...categories, ...response.data])
    })
    const [getToken, isLoading, tokenError] = useFetching(async (userData) => {
        await BackService.login(userData.login, userData.password, setToken)
    })

    useEffect(() => {
        //fetchCategories()
        console.log(nationCategory[0].icon)
        //console.log(categories)
    }, []);

    useEffect(() => {
        console.log(token)
    }, [token]);

    const setTechnicCategory = (value, index) => {
        filterTechnicValue[index].value = value
        console.log(filterTechnicValue)
    }

    const setNationCategory = (value, index) => {
        filterNationValue[index].value = value
        console.log(filterNationValue)
    }

    function loginUser(userData) {
        getToken(userData)
        setModalLogin(false)
    }

    function createUser(userData) {
        console.log(userData)
        setModalCreateUser(false)
    }

    const buy = (id) => {
        console.log(id)
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

                <MenuItem
                    onClick={() => setModalLogin(true)}
                    style={{color: "#ffe8aa"}}
                >
                    Войти
                </MenuItem>
                <MenuItem>
                    Ru
                </MenuItem>
            </Menu>

            <LoginModal visible={modalLogin} setVisible={setModalLogin}>
                <LoginForm login={loginUser} create={() => {setModalLogin(false); setModalCreateUser(true)}}/>
            </LoginModal>
            <CreateModal visible={modalCreateUser} setVisible={setModalCreateUser}>
                <CreateForm create={createUser}/>
            </CreateModal>

            <Nav>
                <NavItem onClick={() => navigate("/")}>
                    H
                </NavItem >
                <NavItem
                    onClick={() => navigate("/premium_currency")}
                    isActiveItem={isPremiumCurrency}
                >
                    Золотые Орлы
                </NavItem>
                <NavItem
                    onClick={() => navigate("/technic")}
                    isActiveItem={isTechnic}
                >
                    Техника
                </NavItem>
                <NavItem
                    onClick={() => navigate("/premium_account")}
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

            {isTechnic
                ?
                <Filter>
                    <FilterLeft>
                        <FilterSelect nameSelect="Техника">
                            {technicCategory.map((technic, index) =>
                                <FilterSelectItem
                                    key={index}
                                    idItem={index}
                                    setFilter={setTechnicCategory}
                                    styleForIcon={technic.icon}
                                >
                                    {technic.name}
                                </FilterSelectItem>
                            )}
                        </FilterSelect>
                        <FilterSelect nameSelect="Нации" isTwoColumn={true}>
                            {nationCategory.map((nation, index) =>
                                <FilterSelectItem
                                    key={index}
                                    styleForIcon={nation.icon}
                                    idItem={index}
                                    setFilter={setNationCategory}
                                >
                                    {nation.name}
                                </FilterSelectItem>
                            )}
                        </FilterSelect>
                    </FilterLeft>
                </Filter>
                :
                <div/>
            }

            <Showcase>
                <ShowcaseItem
                    imageLink="https://static-store.gaijin.net/img/items/063B7FA8-7355-404E-AA64-BFE725D90DC6.jpg"
                    title="Набор 'Я твой рот ебал'"
                    nation="USA"
                    description="Блять какая хуйня это ваше РГЗ. Осипов ПИДОРАС"
                    price="Бесплатно"
                    buyFunction={buy}
                    idProduct={1}
                />
            </Showcase>

        </div>
    );
};

export default Store;