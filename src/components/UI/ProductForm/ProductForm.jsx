import React from 'react';
import classes from "./ProductForm.module.css";

const ProductForm = ({title, image, description, price,...props}) => {
    return (
        <section className={classes.ProductForm}>
            <div className={classes.ProductForm_Title}>
                {title}
            </div>
            <div className={classes.ProductForm_ContentWrapper}>
                <div className={classes.ProductForm_Gallery}>
                    <div className={classes.ProductForm_SpLide}>
                        <img className={classes.ProductForm_image} src={image}/>
                    </div>
                </div>
                <table className={classes.ProductForm_Article_Wrapper}>
                    <tbody>
                        <tr>
                            <td>
                                <div className={classes.ProductForm_Article}>
                                    {description}
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div className={classes.ProductForm_ASide}>
                <div className={classes.ProductForm_ASide_Sticky}>
                    <div className={classes.ProductForm_ShopBuy}>
                        <div className={classes.ProductForm_ShopBuy_Wrapper}>
                            <div className={classes.ProductForm_ShopBuy_Price}>
                                <div className={classes.ProductForm_ShopBuy_Price__}>
                                    {price}
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    );
};

export default ProductForm;