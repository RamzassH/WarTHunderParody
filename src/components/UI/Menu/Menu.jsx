import React from 'react';
import classes from "./Menu.module.css";

const Menu = ({children, ...props}) => {
    return (
        <div className={classes.Menu} {...props}>
            {children}
        </div>
    );
};

export default Menu;