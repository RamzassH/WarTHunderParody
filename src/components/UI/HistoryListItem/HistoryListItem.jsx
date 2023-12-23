import React from 'react';
import classes from "./HistoryListItem.module.css";

const HistoryListItem = ({image, title, price, meta, description}) => {
    return (
        <div className={classes.Item}>
            <div className={[classes.Item__Corners, classes.Item__Corners_Top].join(" ")}></div>
            <div className={[classes.Item__Corners, classes.Item__Corners_Bottom].join(" ")}></div>
            <div className={classes.Item__Preview}>
                <img src={image} style={{width: "100%", height: "auto"}}/>
            </div>
            <div className={classes.Item__Comment}></div>
            <div className={classes.Item__TimeStamp}>{meta}</div>
            <div className={classes.Item__Price}>{price}</div>
            <div className={classes.Item__Description}>
                <div className={classes.Item__Description_Title}>{title}</div>
                <div className={classes.Item__Description_Comment}>{description}</div>
            </div>
        </div>
    );
};

export default HistoryListItem;