import React from 'react';
import classes from "./Widget.module.css";

const Widget = ({children,src,...props}) => {
    return (
        <div {...props} className={classes.Widget}>
            <img src={src} className={classes.WidgetImage}/>
            <div className={classes.WidgetText}>{children}</div>
        </div>
    );
};

export default Widget;