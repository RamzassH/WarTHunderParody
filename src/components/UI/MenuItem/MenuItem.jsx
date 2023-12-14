import React from 'react';
import classes from "./MenuItem.module.css";

const MenuItem = ({children, ...props}) => {
    return (
        <button {...props} className={classes.MenuItem}>
            {children}
        </button>
    );
};

export default MenuItem;