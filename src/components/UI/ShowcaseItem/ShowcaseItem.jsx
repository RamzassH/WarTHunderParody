import React from 'react';
import classes from "./ShowcaseItem.module.css"

const ShowcaseItem = ({imageLink, title, nation, description, price, buyFunction, idProduct, navigateProductPage, ...props}) => {
    return (
        <div className={classes.ShowcaseItem} data-cart-item-id={idProduct}>
            <div className={classes.ShowcaseItemBody} onClick={() => {navigateProductPage(idProduct)}}>
                <div className={classes.ShowcaseItemPoster}>
                    <img className={classes.ShowcaseItemPosterImage} src={imageLink}/>
                </div>
                <div className={[classes.ShowcaseItem__Description, classes.ShowcaseItem_Description].join(" ")}>
                    <div className={classes.ShowcaseItem_Description_GameLabel}>
                        War thunder
                    </div>
                    <div className={classes.ShowcaseItem_Description_Title}>{title}</div>
                    <div className={classes.ShowcaseItem_Description__Comment}>{nation}</div>
                    <table className={classes.ShowcaseItem_Description__ShortDescription}>
                        <tbody>
                            <tr>
                                <td>
                                    <div className={classes.ShowcaseItem_Description__ShortDescription_Text}>
                                        {description}
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div className={classes.ShowcaseItem_Footer}>
                <div className={classes.ShowcaseItem_Price}>
                    <span className={classes.ShowcaseItem_Price_default}>{price}</span>
                </div>
                <div className={classes.ShowcaseItem_Buy}>
                    <div className={classes.ShowcaseItem_Buy_Wrapper}>
                        <div className={classes.ShowcaseItem_Buy__section} onClick={() => buyFunction(idProduct)}>
                            Купить
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default ShowcaseItem;