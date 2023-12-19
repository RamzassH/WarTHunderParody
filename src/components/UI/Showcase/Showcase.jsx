import React from 'react';
import classes from "./Showcase.module.css";

const Showcase = ({children}) => {
    return (
        <div className={classes.Showcase}>
            <div className={classes.ShowcaseContent}>
                {children}
            </div>
        </div>
    );
};

export default Showcase;