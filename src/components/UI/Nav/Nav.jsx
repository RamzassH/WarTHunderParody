import React from 'react';
import classes from "./Nav.module.css";

const Nav = ({children, ...props}) => {
    return (
        <div {...props} className={classes.Nav}>
            {children}
        </div>
    );
};

export default Nav;