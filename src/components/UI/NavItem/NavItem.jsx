import React from 'react';
import classes from "./NavItem.module.css";

const NavItem = ({children, isActiveItem = false, ...props}) => {
    return (
        <button {...props} className={!isActiveItem ? classes.NavItem : classes.NavItemCurrentActive}>
            {children}
        </button>
    );
};

export default NavItem;