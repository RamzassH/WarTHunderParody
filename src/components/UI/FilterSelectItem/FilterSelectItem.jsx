import React from 'react';
import classes from "./FilterSelectItem.module.css";

const FilterSelectItem = ({check, children, setFilter, idItem, styleForIcon,...props}) => {
    //let check = false
    let classFlag = [classes.Flag]
    if (styleForIcon) {
        classFlag.push(styleForIcon)
    }
    let tmp = check;
    return (
        <li className={classes.FilterSelectItem} {...props}>
            <input
                className={classes.FilterSelectItemCheckBox}
                type="checkbox"
                value={tmp}
                onClick={() => {
                    tmp = !tmp
                    setFilter(tmp, idItem)
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