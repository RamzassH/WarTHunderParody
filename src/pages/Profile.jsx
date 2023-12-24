import React, {useContext, useEffect, useState} from 'react';
import MenuItem from "../components/UI/MenuItem/MenuItem";
import MenuItemProfile from "../components/UI/MenuItemProfile/MenuItemProfile";
import Menu from "../components/UI/Menu/Menu";
import {AuthContext} from "../context";
import {useNavigate} from "react-router-dom";
import ProfileSection from "../components/UI/ProfileSection/ProfileSection";
import ProfileMenu from "../components/UI/ProfileMenu/ProfileMenu";
import ProfileMenuItem from "../components/UI/ProfileMenuItem/ProfileMenuItem";
import ProfileInfo from "../components/UI/ProfileInfo/ProfileInfo";
import HistoryList from "../components/UI/HistoryList/HistoryList";
import HistoryListItem from "../components/UI/HistoryListItem/HistoryListItem";
import AddProductForm from "../components/UI/AddProductForm/AddProductForm";
import {useFetching} from "../hooks/useFetching";
import BackService from "../API/BackService";
import product from "./Product";
import MyButton from "../components/UI/button/MyButton";

const Profile = () => {
    const {isAuth, setIsAuth, token, setToken, userInfoFromToken} = useContext(AuthContext)

    const [fileUrl, setFileUrl] = useState("")
    const [info, setInfo] = useState({username: '', id: '', email: '', date: ''})
    const [historyList, setUserHistory] = useState([])
    const [isProfileInfo, setIsProfileInfo] = useState(true)
    const [isHistory, setIsHistory] = useState(false)
    const [isAddProduct, setIsAddProduct] = useState(false)
    const [isDischarge, setIsDischarge] = useState(false)
    const [isAdmin, setIsAdmin] = useState(false)
    let navigate = useNavigate()
    const [getInfo, isLoadInfo, errorInfo] = useFetching(async (data) => {
        const response = await BackService.getAccountInfo(data);
        setInfo({username: response.data.name, id: response.data.id,
            date: response.data.registrationDate, email: response.data.email})

    })
    const [getUserHistory, isLoadHistory, historyError] = useFetching(async () =>{
        const response = await BackService.getUserHistory(token.token)
        setUserHistory([...response.data])
    })

    const [getJsonURl, isLoadJsonURL, errorJsonURL] = useFetching(async () => {
        const response = await  BackService.getProductsJSON(token.token)
        setFileUrl(response.data)
    })
    const [getCsvURl, isLoadCsvURL, errorCsvURL] = useFetching(async () => {
        const response = await  BackService.getProductsCSV(token.token)
        setFileUrl(response.data)
    })

    useEffect(() => {
        if (typeof userInfoFromToken.role !== 'string') {
            userInfoFromToken.role.map(userRole => {
                if (!userRole.localeCompare('Admin')) {
                    setIsAdmin(true)
                }
            })
        }
        else if (!userInfoFromToken.role.localeCompare('Admin')){
            setIsAdmin(true);
        }
        getInfo(localStorage.getItem('token'))
    }, [token]);


    useEffect(() => {
        getUserHistory()
    }, [isHistory]);

    useEffect(() => {
        console.log(info)
    }, [info]);
    function clickProfileInfo() {
        if (isHistory) {
            setIsHistory(false)
        }
        if (isAddProduct) {
            setIsAddProduct(false)
        }
        if (isDischarge) {
            setIsDischarge(false)
        }
        setIsProfileInfo(true)
    }



    function getJson(event) {
        event.preventDefault();
        getJsonURl()
    }
    function getCsv(event) {
        event.preventDefault();
        getCsvURl()
    }
    function Exit(functionIsAuth, functionToken) {
        localStorage.setItem("auth", 'false');
        localStorage.setItem("token", "");
        localStorage.setItem("username", "")
        functionIsAuth(false);
        functionToken({token: "", username: ""});
    }
    function clickHistory() {
        if (isProfileInfo) {
            setIsProfileInfo(false)
        }
        if (isAddProduct) {
            setIsAddProduct(false)
        }
        if (isDischarge) {
            setIsDischarge(false)
        }
        setIsHistory(true)
    }

    function clickAddProduct() {
        if (isProfileInfo) {
            setIsProfileInfo(false)
        }
        if (isHistory) {
            setIsHistory(false)
        }
        if (isDischarge) {
            setIsDischarge(false)
        }
        setIsAddProduct(true)
    }

    function clickDischarge() {
        if (isProfileInfo) {
            setIsProfileInfo(false)
        }
        if (isHistory) {
            setIsHistory(false)
        }
        if (isAddProduct) {
            setIsAddProduct(false)
        }
        setIsDischarge(true)
    }

    return (
        <div style={{
            display: "flex",
            width: "100%",
            flexDirection: 'column',
            alignItems: 'center',
        }}>
            <Menu style={{marginBottom: "20px"}}>
                <MenuItem>
                    L
                </MenuItem>
                <MenuItem>
                    Игры
                </MenuItem>
                <MenuItem onClick={() => {
                    navigate('/')
                }}>
                    Магазин
                </MenuItem>
                <MenuItem style={{marginRight: "auto"}}>
                    Поддержка
                </MenuItem>

                {!isAuth
                    ?
                    null
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

            <div style={{
                position: "absolute",
                zIndex: "-1",
                left: "0",
                top: "0",
                width: "100%",
                height: "80px",
                background: "linear-gradient(to bottom, rgba(3, 12, 21, 0.2) 0%, transparent 100%)"
            }}>
            </div>

            <ProfileSection>
                <ProfileMenu>
                    <ProfileMenuItem isActive={isProfileInfo} setActive={clickProfileInfo}>
                        Ваш профиль
                    </ProfileMenuItem>
                    <ProfileMenuItem isActive={isHistory} setActive={clickHistory}>
                        История покупок
                    </ProfileMenuItem>

                    {isAdmin
                        ?
                        <ProfileMenuItem isActive={isAddProduct} setActive={clickAddProduct}>
                            Добавить новый набор подпиваса
                        </ProfileMenuItem>
                        :
                        null
                    }
                    {isAdmin
                        ?
                        <ProfileMenuItem isActive={isDischarge} setActive={clickDischarge}>
                            Выгрузка или что-то другое
                        </ProfileMenuItem>
                        :
                        null
                    }
                </ProfileMenu>

                {isProfileInfo
                    ?
                    <ProfileInfo
                        username={info.username}
                        id={info.id}
                        email={info.email}
                        meta={info.date}
                    />
                    :
                    null
                }

                {isHistory
                    ?
                    <HistoryList>`
                        {
                            historyList.map(product =>
                                <HistoryListItem
                                    image={product.image}
                                    title={product.name}
                                    price={product.price}
                                    description={product.nationId}
                                    meta={product.date}
                                />

                            )

                        }
                    </HistoryList>
                    :
                    null
                }

                {isAddProduct
                    ?
                    <AddProductForm/>
                    :
                    null
                }
                {isDischarge
                    ?
                    <div style={{display:"flex", width:"300px", height:"400px"}}>
                        <MyButton onClick = {getJson}>
                            Получить продукты в JSON
                        </MyButton>
                        <MyButton onClick = {getCsv}>
                            Получить продукты в CSV
                        </MyButton>
                        <div>
                            {fileUrl}
                        </div>
                    </div>
                    :
                    null
                }
            </ProfileSection>
        </div>
    );
};

export default Profile;