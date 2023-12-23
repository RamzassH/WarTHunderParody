import React from 'react';
import classes from "./ProfileMenuItem.module.css";

const ProfileMenuItem = ({children, isActive, setActive, ...props}) => {
    let rootClasses = [classes.ProfileMenuItem]
    if (isActive) {
        rootClasses.push(classes.ProfileMenuItem_Active)
    }

    return (
        <a className={rootClasses.join(" ")} onClick={() => {if (!isActive) { setActive()}}}>
            {children}
        </a>
    );
};

export default ProfileMenuItem;