import React, {useContext, useState} from 'react';
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

const Profile = () => {
    const {isAuth, setIsAuth} = useContext(AuthContext)

    const [isProfileInfo, setIsProfileInfo] = useState(true)
    const [isHistory, setIsHistory] = useState(false)
    const [isAddProduct, setIsAddProduct] = useState(false)
    const [isDischarge, setIsDischarge] = useState(false)
    const [isAdmin, setIsAdmin] = useState(true)
    let navigate = useNavigate()


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
                <MenuItem onClick={() => {navigate('/')}}>
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
                        profileFunction={() => {navigate('/profile')}}
                        exitFunction={() => {setIsAuth(false); localStorage.setItem('auth', 'false'); navigate('/')}}
                        username="TiltMan"
                    />
                }
                <MenuItem>
                    Ru
                </MenuItem>
            </Menu>

            <div style={{position: "absolute",
                zIndex: "-1",
                left: "0",
                top: "0",
                width: "100%",
                height: "80px",
                background: "linear-gradient(to bottom, rgba(3, 12, 21, 0.2) 0%, transparent 100%)"}}>
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
                        username="Я уже в тильте. А ты???"
                        id="1337"
                        email="siniyLamborginy@zov.ussr"
                        meta="9 мая 1945 года"
                    />
                    :
                    null
                }

                {isHistory
                    ?
                    <HistoryList>
                        <HistoryListItem
                            image="https://store.gaijin.net/img/items/B9E88B57-8BFC-4FB3-9EA9-9ED00DA44847.jpg"
                            title="Пивной прорыв"
                            price="Балтика 9"
                            description="СССР"
                            meta="24.02.2022"
                        />
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

            </ProfileSection>
        </div>
    );
};

export default Profile;