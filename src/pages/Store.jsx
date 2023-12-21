import React, {useContext, useEffect, useState} from 'react';
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
import {getPageCount} from "../utils/pages";
import {AuthContext} from "../context";
import MenuItemProfile from "../components/UI/MenuItemProfile/MenuItemProfile";

const Store = ({isTechnic = false, isPremiumCurrency = false, isPremiumAccount = false}) => {
    const {isAuth, setIsAuth} = useContext(AuthContext)

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

    const [filterTechnicValue, setFilterTechnicValue] = useState([{id: 1, value: false},
        {id: 2, value: false},
        {id: 3, value: false},
        {id: 4, value: false}])
    const [filterNationValue, setFilterNationValue] = useState([
        {id: 1, value: false},
        {id: 2, value: false},
        {id: 3, value: false},
        {id: 4, value: false},
        {id: 6, value: false},
        {id: 7, value: false},
        {id: 5, value: false},
        {id: 8, value: false},
        {id: 9, value: false},
        {id: 10, value: false}
    ])

    let navigate = useNavigate()


    const [productList, setProductList] = useState([])
    const [modalLogin, setModalLogin] = useState(false)
    const [modalCreateUser, setModalCreateUser] = useState(false)
    //const [categories, setCategories] = useState([])
    const [token, setToken] = useState("");
    //const [totalPages, setTotalPages] = useState(0);
    const [limit, setLimit] = useState("10");
    const [page, setPage] = useState("1");
    const [isActiveFirstFilter, setActiveFilter1] = useState(false)
    const [isActiveSecondFilter, setActiveFilter2] = useState(false)
    const [getToken, isLoading, tokenError] = useFetching(async (userData) => {
        await BackService.login(userData.login, userData.password, setToken)

    })
    const [getTechnique, isLoadingTechnique, errorTechnique] = useFetching(async (limit, page) => {
        const response = await BackService.getTechnique(limit, page)
        setProductList(response.data)
        //setProductList([{},{},{},{},{}])
        //const totalCount = response.headers['total-count-categories']
        //setTotalPages(getPageCount(totalCount, limit));
    })
    const [getPremiumAccounts, isLoadingAccounts, errorAccounts] = useFetching(async (limit, page) => {
        const response = await BackService.getPremiumAccounts(limit, page)
        setProductList(response.data)
        //setProductList([{}, {}])
        //const totalCount = response.headers['total-count-categories']
        //setTotalPages(getPageCount(totalCount, limit));
    })
    const [getPremiumCurrency, isLoadingCurrency, errorCurrency] = useFetching(async (limit, page) => {
        const response = await BackService.getPremiumCurrency(limit, page)
        setProductList(response.data)
        //setProductList([{},{},{},{}])
        //const totalCount = response.headers['total-count-categories']
        //setTotalPages(getPageCount(totalCount, limit));
    })
    const [getTechnicByFilter, isLoadingByFilter, errorByFilter] = useFetching(async (limit, page) => {
        const response = await BackService.GetTechnicByFilter(limit, page, filterTechnicValue, filterNationValue)
        setProductList(response.data)
    })
    const [register, IsRegistration, errorRegistration] = useFetching(async (data) => {
        const response = await BackService.register(data.login, data.username, data.password)
    })

    useEffect(() => {
        console.log(filterTechnicValue)
        console.log(filterNationValue)
    }, [filterTechnicValue,filterNationValue]);

    useEffect(() => {
        if (isTechnic) {
            getTechnique(limit, page)
        } else if (isPremiumAccount) {
            getPremiumAccounts(limit, page)
        } else if (isPremiumCurrency) {
            getPremiumCurrency(limit, page)
        }
    }, [isTechnic, isPremiumCurrency, isPremiumAccount]);

    useEffect(() => {
        if (isTechnic) {
            getTechnique(limit, page)
        } else if (isPremiumAccount) {
            getPremiumAccounts(limit, page)
        } else if (isPremiumCurrency) {
            getPremiumCurrency(limit, page)
        }
    }, [limit, page]);

    const setTechnicCategory = (value, index) => {
        let tmp = [...filterTechnicValue]
        tmp[index] = {...tmp[index], value: value}
        setFilterTechnicValue(tmp)
    }

    const setNationCategory = (value, index) => {
        let tmp = [...filterNationValue]
        tmp[index] = {...tmp[index], value: value}
        setFilterNationValue(tmp)
    }

    function loginUser(userData) {
        //getToken(userData)
        setIsAuth(true)
        localStorage.setItem('auth', 'true')
        setModalLogin(false)
    }

    function createUser(userData) {
        console.log(userData)
        register(userData)
        setModalCreateUser(false)
    }

    const navigateProductPage = (idProduct) => {
        let type = ''
        if (isTechnic) {
            type = 'technic'
        } else if (isPremiumAccount) {
            type = 'premium_account'
        } else {
            type = 'premium_currency'
        }

        navigate(`/${type}/${idProduct}`)
    }

    const buy = (id) => {
        console.log(id)
    }

    const applyFilter = () => {
        console.log(filterTechnicValue)
        console.log(filterNationValue)
        getTechnicByFilter(limit, page)
        if (errorByFilter) {
            setProductList([]);
        }
    }

    const clickFirstFilter = () => {
        if (isActiveSecondFilter) {
            setActiveFilter2(!isActiveSecondFilter)
        }
        setActiveFilter1(!isActiveFirstFilter)
    }

    const clickSecondFilter = () => {
        if (isActiveFirstFilter) {
            setActiveFilter1(!isActiveFirstFilter)
        }
        setActiveFilter2(!isActiveSecondFilter)
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
                        profileFunction={() => {navigate('/profile')}}
                        exitFunction={() => {setIsAuth(false); localStorage.setItem('auth', 'false'); navigate('/')}}
                        username="TiltMan"
                    />
                }


                <MenuItem>
                    Ru
                </MenuItem>
            </Menu>

            <LoginModal visible={modalLogin} setVisible={setModalLogin}>
                <LoginForm login={loginUser} create={() => {
                    setModalLogin(false);
                    setModalCreateUser(true)
                }}/>
            </LoginModal>
            <CreateModal visible={modalCreateUser} setVisible={setModalCreateUser}>
                <CreateForm create={createUser}/>
            </CreateModal>

            <Nav>
                <NavItem onClick={() => navigate("/")}>
                    H
                </NavItem>
                <NavItem
                    onClick={() => {
                        navigate("/premium_currency");
                    }}
                    isActiveItem={isPremiumCurrency}
                >
                    Золотые Орлы
                </NavItem>
                <NavItem
                    onClick={() => {
                        navigate("/technic");
                    }}
                    isActiveItem={isTechnic}
                >
                    Техника
                </NavItem>
                <NavItem
                    onClick={() => {
                        navigate("/premium_account");
                    }}
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
                        <FilterSelect
                            isActive={isActiveFirstFilter}
                            onClickButton={applyFilter}
                            setActive={clickFirstFilter}
                            nameSelect="Техника"
                        >
                            {technicCategory.map((technic, index) =>
                                <FilterSelectItem
                                    check={filterTechnicValue[index].value}
                                    key={index}
                                    idItem={index}
                                    setFilter={setTechnicCategory}
                                    styleForIcon={technic.icon}
                                >
                                    {technic.name}
                                </FilterSelectItem>
                            )}
                        </FilterSelect>
                        <FilterSelect
                            isActive={isActiveSecondFilter}
                            onClickButton={applyFilter}
                            setActive={clickSecondFilter}
                            nameSelect="Нации"
                            isTwoColumn={true}
                        >
                            {nationCategory.map((nation, index) =>
                                <FilterSelectItem
                                    check={filterNationValue[index].value}
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
                {/*<ShowcaseItem
                    imageLink="https://static-store.gaijin.net/img/items/063B7FA8-7355-404E-AA64-BFE725D90DC6.jpg"
                    title="Набор 'Я твой рот ебал'"
                    nation="USA"
                    description="Блять какая хуйня это ваше РГЗ. Осипов ПИДОРАС"
                    price="Бесплатно"
                    buyFunction={buy}
                    idProduct={1}
                />*/}
                {productList.map((product, index) =>
                    <ShowcaseItem
                        navigateProductPage={navigateProductPage}
                        key={product.id}
                        imageLink={product.image}
                        title={product.name}
                        description={product.description}
                        price={product.price}
                        buyFunction={buy}
                        idProduct={product.id}
                    />
                )}
            </Showcase>

        </div>
    );
    /*
                        key = {product.id}
                        imageLink={product.image}
                        title={product.name}
                        description={product.description}
                        price={product.price}
                        buyFunction={buy}
                        idProduct={product.id}
    */
};

export default Store;