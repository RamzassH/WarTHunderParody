import React from 'react';
import classes from "./FilterLeft.module.css";

const FilterLeft = ({children}) => {
    return (
        <div className={classes.FilterLeft}>
            <div className={classes.FilterMobilePopup}>
                {children}
            </div>
        </div>
    );
};

export default FilterLeft;