import React from 'react';
import classes from "./Menu.module.css";

const Menu = ({children}) => {
    return (
        <div className={classes.Menu}>
            {children}
        </div>
    );
};

export default Menu;