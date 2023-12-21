import React, {useState} from 'react';
import classes from "./MenuItemProfile.module.css";

const MenuItemProfile = ({username, profileFunction, exitFunction,...props}) => {
    const [isDrop, setIsDrop] = useState(false)

    return (
        <div className={classes.MenuItemProfile} onClick={(event) => {event.preventDefault(); setIsDrop(!isDrop)}}>
            <div className={classes.MenuItemProfile_Label}>
                {username}
            </div>
            {isDrop
                ?
                <div className={classes.MenuItemProfile_Drop}>
                    <div className={classes.MenuItemProfile_Dropdown}>
                        <div className={classes.MenuItemProfile_Dropdown_Item} onClick={() => profileFunction()}>
                            <div className={classes.MenuItemProfile_Dropdown_ItemLabel}>
                                Профиль
                            </div>
                        </div>
                        <div className={classes.MenuItemProfile_List_Divider}></div>
                        <div className={classes.MenuItemProfile_Dropdown_Item} onClick={() => exitFunction()}>
                            <div className={classes.MenuItemProfile_Dropdown_ItemLabel}>
                                Выход
                            </div>
                        </div>
                    </div>
                </div>
                :
                null
            }
        </div>
    );
};

export default MenuItemProfile;