import React, {useContext} from 'react';
import MenuItem from "../components/UI/MenuItem/MenuItem";
import MenuItemProfile from "../components/UI/MenuItemProfile/MenuItemProfile";
import Menu from "../components/UI/Menu/Menu";
import {AuthContext} from "../context";
import {useNavigate} from "react-router-dom";

const Profile = () => {
    const {isAuth, setIsAuth} = useContext(AuthContext)
    let navigate = useNavigate()

    return (
        <div style={{
            display: "flex",
            width: "100%",
            flexDirection: 'column',
            alignItems: 'center',
        }}>
            <Menu>
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
        </div>
    );
};

export default Profile;