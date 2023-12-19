import React, {useState} from 'react';
import classes from "./Filter.module.css";

const Filter = ({children, ...props}) => {
    const [filter, setFilter] = useState({t:''})

    return (
        <div className={classes.Filter}>
            <div className={classes.FilterWrapper}>
                {children}
            </div>
        </div>
    );
};

export default Filter;