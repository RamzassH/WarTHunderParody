import React from 'react';
import classes from "./ProfileMenu.module.css";

const ProfileMenu = ({children, ...props}) => {
    return (
        <div className={classes.ProfileMenu}>
            <div className={classes.ProfileMenu_Wrapper}>
                {children}
            </div>
        </div>
    );
};

export default ProfileMenu;