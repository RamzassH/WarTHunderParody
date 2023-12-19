import React from 'react';
import classes from "./FilterSelectItem.module.css";

const FilterSelectItem = ({children, setFilter, idItem, styleForIcon,...props}) => {
    let check = false
    let classFlag = [classes.Flag]
    if (styleForIcon) {
        classFlag.push(styleForIcon)
    }

    return (
        <li className={classes.FilterSelectItem} {...props}>
            <input
                className={classes.FilterSelectItemCheckBox}
                type="checkbox"
                value={check.toString()}
                onClick={() => {
                    check = !check
                    setFilter(check, idItem)
                }}
            />
            <span>
                <i className={classFlag.join(" ")}/>
                {children}
            </span>
        </li>
    );
};

export default FilterSelectItem;