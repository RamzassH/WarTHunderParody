import React, {useState} from 'react';
import classes from "./FilterSelect.module.css";

const FilterSelect = ({nameSelect="" ,children, isTwoColumn = false, ...props}) => {
    let [isActive, setIsActive] = useState(false)
    let [isNotEmpty, setIsNotEmpty] = useState(false)
    let rootClasses = [classes.FilterSelect]
    let dropListClasses = [classes.FilterSelectDropdownList]

    if (isActive) {
        rootClasses.push(classes.FilterSelectActive)
    }
    if (isNotEmpty) {
        rootClasses.push(classes.FilterSelectNotEmpty)
    }
    if (isTwoColumn) {
        dropListClasses.push(classes.FilterSelectDropdownListTwoColumns)
    }

    return (
        <div className={rootClasses.join(" ")} onClick={() => setIsActive(!isActive)}>
            <div className={classes.FilterSelectLabel}>
                {nameSelect}
            </div>
            <div className={classes.FilterSelectCurrent}>
                <svg className={classes.FilterSelectArrow}>
                </svg>
                <span>
                    Все
                </span>
            </div>
            <div className={classes.FilterSelectDropdown} onClick={(e) => e.stopPropagation()}>
                <ul className={dropListClasses.join(" ")}>
                    {children}
                </ul>
            </div>

        </div>
    );
};

export default FilterSelect;