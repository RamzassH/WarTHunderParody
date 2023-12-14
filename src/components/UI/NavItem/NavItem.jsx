import React from 'react';
import classes from "./NavItem.module.css";

const NavItem = ({children, ...props}) => {
    return (
        <button {...props} className={classes.NavItem}>
            {children}
        </button>
    );
};

export default NavItem;