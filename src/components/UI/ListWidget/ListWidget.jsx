import React from 'react';
import classes from "./ListWidget.module.css";

const ListWidget = ({children, ...props}) => {
    return (
        <div {...props} className={classes.ListWidget}>
            {children}
        </div>
    );
};

export default ListWidget;