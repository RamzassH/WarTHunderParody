import React, {useState} from 'react';
import classes from "./FilterSelect.module.css";

const FilterSelect = ({nameSelect="" ,children, onClickButton, isActive, setActive, isTwoColumn = false, ...props}) => {
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
        <div className={rootClasses.join(" ")} onClick={() => setActive()}>
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
                <div
                    className={[classes.FilterSelect_Button_1, classes.FilterSelect_Button_2, classes.FilterSelect_Button_3].join(" ")}
                    onClick={(event) => {event.preventDefault();onClickButton();setActive()}}
                >
                    Применить
                </div>
            </div>

        </div>
    );
};

export default FilterSelect;