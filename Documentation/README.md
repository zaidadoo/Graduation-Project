---
title: Contactless Dining System Report
---

> *Zaid Issa 20190148*
>
> Contents

[GUI Documentation 2](#gui-documentation)

[Initial Setup 2](#initial-setup)

[Main Menu 3](#main-menu)

[Orders being prepared display 3](#orders-being-prepared-display)

[Customer Ordering Menu Splash Screen
4](#customer-ordering-menu-splash-screen)

[Management Menu 4](#management-menu)

[Cashier Side 5](#cashier-side)

[Kitchen Side 6](#kitchen-side)

[Manager Retrieve All Orders 7](#manager-retrieve-all-orders)

[Restaurant Info Manager 7](#restaurant-info-manager)

[Manage Menu Items 8](#manage-menu-items)

[Customer Menu 8](#customer-menu)

[Extra Windows Forms 10](#extra-windows-forms)

[Code Implementation 12](#code-implementation)

[Form1.cs 12](#form1.cs)

[Form2.cs 13](#form2.cs)

[Form3.cs 14](#form3.cs)

[Form4.cs 15](#form4.cs)

[Form5.cs 16](#form5.cs)

[CompleteMenu.cs 33](#completemenu.cs)

[MenuItem.cs 37](#menuitem.cs)

[OrderedItem.cs 38](#ordereditem.cs)

[Order.cs 39](#order.cs)

[PasswordChecker.cs 41](#passwordchecker.cs)

[Program.cs 42](#program.cs)

# GUI Documentation

## ![](vertopal_028555db347b44f2bf226a6a7176665b/media/image1.png){width="6.232430008748906in" height="5.183333333333334in"}Initial Setup

> In the initial setup, the restaurant can add their restaurant logo,
> name, and manager password. After submitting the proper details, they
> will be taken to the main menu.

## ![](vertopal_028555db347b44f2bf226a6a7176665b/media/image2.jpeg){width="6.478087270341208in" height="3.6954166666666666in"}Main Menu

> In the main menu, the restaurant is able to access the different
> panels based on their needs. If customer display is accessed, then
> it'll take them to the display that shows the customers which order
> IDs are being prepared at the moment. If customer menu is clicked,
> then the customer menu will open allowing the customer to order from
> the restaurant's menu. Finally, if the kitchen management is clicked,
> then
>
> it'll ask for the manager password before allowing them in.

## Orders being prepared display

> ![](vertopal_028555db347b44f2bf226a6a7176665b/media/image3.png){width="6.432097550306212in"
> height="2.98375in"}
>
> In the customer display, the logo of the restaurant is loaded on the
> left; while on the right, all the order IDs of orders being prepared
> will show up automatically, and refresh every 5 seconds.

## ![](vertopal_028555db347b44f2bf226a6a7176665b/media/image4.png){width="6.523332239720035in" height="3.402603893263342in"}Customer Ordering Menu Splash Screen

> The splash screen displays the restaurant name and their logo. Once
> the customer clicks on start order
>
> it'll reveal the complete menu, where they could order.

## ![](vertopal_028555db347b44f2bf226a6a7176665b/media/image5.png){width="6.523137576552931in" height="1.0865616797900262in"}Management Menu

> The kitchen management tabs allow us to navigate the kitchen
> management; in addition, in the top right corner, the manager could
> lock the current tab open, so employees don't change their designated
> tab; manager could also click back to go back to main menu, exit to
> close the software, or sign out from manager mode.

## ![](vertopal_028555db347b44f2bf226a6a7176665b/media/image6.png){width="6.544531933508312in" height="3.424165573053368in"}Cashier Side

> Cashier tab allows the employee to view the orders pending or being
> prepared. Orders viewed here can be modified as per the following:
> confirm an order is paid, cancel an order, or complete an order once
> customers receive it.

## ![](vertopal_028555db347b44f2bf226a6a7176665b/media/image7.png){width="6.519025590551181in" height="3.854582239720035in"}Kitchen Side

> Kitchen tab shows the orders need to get prepared, while the ordered
> items show the item name, and the quantity.

## ![](vertopal_028555db347b44f2bf226a6a7176665b/media/image8.png){width="6.506842738407699in" height="3.77in"}Manager Retrieve All Orders

> This tab allows the manager to view all orders with any status.

## ![](vertopal_028555db347b44f2bf226a6a7176665b/media/image9.png){width="6.554783464566929in" height="3.896874453193351in"}Restaurant Info Manager

> This tab allows the manager to change the restaurant name, password,
> or logo set before.

## ![](vertopal_028555db347b44f2bf226a6a7176665b/media/image10.png){width="6.550018591426071in" height="3.9148950131233597in"}Manage Menu Items

> This tab allows the manager to delete, modify, and insert items on the
> restaurant menu.

## Customer Menu

> ![](vertopal_028555db347b44f2bf226a6a7176665b/media/image11.png){width="6.512928696412948in"
> height="3.1309372265966755in"}
>
> The restaurant logo is loaded from the database on the left. Under
> that is the categories a customer can
>
> navigate through, and depending on which category is clicked, it'll
> display items under that category.
>
> ![](vertopal_028555db347b44f2bf226a6a7176665b/media/image12.png){width="6.21875in"
> height="6.364583333333333in"}
>
> The back button allows the user to cancel their order, then the panel
> will go back to the splash screen.
>
> Under the "YOUR ORDER" label all the items in the cart would appear.
>
> ![](vertopal_028555db347b44f2bf226a6a7176665b/media/image13.png){width="6.083333333333333in"
> height="5.229166666666667in"}
>
> Total would automatically show the cart's total cost. The checkout
> allows the customer to print the receipt that they could show to
> cashier to pay and confirm their order. The clear all button allows
> the customer to delete all the items in their cart.

## Extra Windows Forms

> ![](vertopal_028555db347b44f2bf226a6a7176665b/media/image14.png){width="6.513908573928259in"
> height="1.431874453193351in"}
>
> This user control loads the item name and its price. Once the plus
> button has been clicked, it'll be added
>
> to the cart.
>
> ![](vertopal_028555db347b44f2bf226a6a7176665b/media/image15.png){width="5.0625in"
> height="1.53125in"}
>
> This user control loads the item name, quantity, and price from the
> cart.

![](vertopal_028555db347b44f2bf226a6a7176665b/media/image16.png){width="5.5627701224846895in"
height="2.8541666666666665in"}

> This form is a custom dialog where it checks if the user is able to
> access manager level forms.

# Code Implementation

## ![](vertopal_028555db347b44f2bf226a6a7176665b/media/image17.jpeg){width="8.499998906386702in" height="6.229026684164479in"}Form1.cs

-   LogoUpload_Click opens an OpenFileDialog that only accepts image
    > type files. If image is received, we update the box with the
    > uploaded image.

-   ExitButton_Click closes the application.

-   SubmitPassword_Click checks if user wants to submit details, if no,
    > return. We check if text is valid and logo has been uploaded;
    > then, we connect to the database and upload the details using
    > insert.

-   Logo has to be converted into a byte array in order to be sent to
    > database.

## ![](vertopal_028555db347b44f2bf226a6a7176665b/media/image18.jpeg){width="8.499998906386702in" height="7.1322222222222225in"}Form2.cs

-   ExitButton_Click exits application.

-   Choice1Access_Click and Choice2Access_Click creates a new form
    > object, hides the main menu form, then shows the new form object
    > created (depending on choice).

-   Choice3Access_Click checks for password using the PasswordChecker
    > form before giving access to kitchen management form. A try catch
    > operation has been used here due to deleted object might being
    > used.

## ![](vertopal_028555db347b44f2bf226a6a7176665b/media/image19.jpeg){width="8.499998906386702in" height="7.579444444444444in"}Form3.cs

-   CustomerOrdersDIsplay_Load retrieves restaurant logo from database
    > and shows it in the picture box set. Then it creates an interval
    > timer that keeps activating ordersTImer_Tick function.

-   ordersTimer_Tick function is activated each 5 seconds to retrieve
    > info from database. The info retrieved checks the order numbers
    > for the orders being prepared at the moment, if none then it'll
    > show that.

## ![](vertopal_028555db347b44f2bf226a6a7176665b/media/image20.jpeg){width="8.499998906386702in" height="7.229722222222223in"}Form4.cs

-   Load event gets the restaurant logo and name from database then sets
    > the image in the picture box and changes the splash screen welcome
    > text depending on restaurant name.

-   StartOrder_Click starts the CompleteMenu user control that allows
    > customers to order from.

## ![](vertopal_028555db347b44f2bf226a6a7176665b/media/image21.jpeg){width="8.499998906386702in" height="6.570972222222222in"}Form5.cs

-   Load event disables buttons for cashier side, and disables all tab
    > navigation (unless user is admin)

-   exitToolStripMenuItem_Click checks if navigation is locked, if not
    > user can exit.

-   Tabs_SelectedIndexChanged changes the only enabled tabpage depending
    > on which page the user on (and if it's lock screen is on or not).

![](vertopal_028555db347b44f2bf226a6a7176665b/media/image22.jpeg){width="8.499998906386702in"
height="6.378472222222222in"}

-   adminToolStripMenuItem_Click checks if user is admin, if not create
    > a prompt asking for password. If isAdmin true then they are able
    > to sign out or enable/disable lock screen feature.

-   Tabs_Selecting checks if lock screen is enabled/disabled and cancels
    > tab navigation if lock screen is enabled.

![](vertopal_028555db347b44f2bf226a6a7176665b/media/image23.jpeg){width="8.499998906386702in"
height="6.920833333333333in"}

-   Checks if the list item selected is changed, if yes then it connects
    > to database and retrieves the items ordered depending on the order
    > ID. Try and catch has been used here due to datareader method
    > having connection errors. String methods have been used in order
    > to get each item from the order (since it was boxed without nice
    > styling).

![](vertopal_028555db347b44f2bf226a6a7176665b/media/image24.jpeg){width="8.499998906386702in"
height="7.028472222222222in"}

-   Total gets the total cost for the order and displays it in a label.
    > It then checks which status the order is in, and depending on that
    > the buttons enabled for the cashier side will change.

![](vertopal_028555db347b44f2bf226a6a7176665b/media/image25.jpeg){width="8.499998906386702in"
height="6.800416666666667in"}

-   Both click events act the same, it checks if the user is sure with
    > their action, if not return. After that it connects to the databse
    > and updates the order record to the required status (depending on
    > the order id). Finally, it disables the modification groupbox, and
    > refreshes the orders view list.

![](vertopal_028555db347b44f2bf226a6a7176665b/media/image26.jpeg){width="8.499998906386702in"
height="7.3116666666666665in"}

-   KitRetrieveOrders_Click gets all the orders records that's have a
    > status of "preparing" and display it for the kitchen staff.

-   Selected index changed event works the same way as the cashier side
    > event.

![](vertopal_028555db347b44f2bf226a6a7176665b/media/image27.jpeg){width="8.499998906386702in"
height="6.460416666666666in"}

-   RetrieveAllOrders_Click gets all the orders in the database with any
    > status for the managers to view, a potential option could be to
    > output results in a excel sheet.

-   RefreshData_Click checks if user an admin, if not then it'll ask for
    > user to login with manager password.

![](vertopal_028555db347b44f2bf226a6a7176665b/media/image28.jpeg){width="8.499998906386702in"
height="7.337498906386702in"}

-   RefreshData_Click continuation: if user is an admin, we get
    > restaurant info from database and display it in the fields given;
    > the user then can change any data and submit it to database.

![](vertopal_028555db347b44f2bf226a6a7176665b/media/image29.jpeg){width="8.499998906386702in"
height="6.332638888888889in"}

-   SubmitPassword_Click checks if user an admin again. Then we check to
    > make sure user is sure they want to submit details.

![](vertopal_028555db347b44f2bf226a6a7176665b/media/image30.jpeg){width="8.499998906386702in"
height="6.818611111111111in"}

-   Before submitting, we check if user uploaded a new logo or wants to
    > keep the old one, then send it to database accordingly.

-   ModifyItems_Click enables medication panel

-   AddNewItems_Click enables new item form fields to submit.

![](vertopal_028555db347b44f2bf226a6a7176665b/media/image31.jpeg){width="8.499998906386702in"
height="7.614583333333333in"}

-   Radio button shows menu items in the list depending on which
    > category was chosen from the group box.

![](vertopal_028555db347b44f2bf226a6a7176665b/media/image32.jpeg){width="8.499998906386702in"
height="6.820833333333334in"}

-   Continuation of the above.

![](vertopal_028555db347b44f2bf226a6a7176665b/media/image33.jpeg){width="8.499998906386702in"
height="6.865277777777778in"}

-   If one of the menu items were selected from the list, then it takes
    > the item id from the string in list and searches for it in the
    > database. The database then gets it in order for user to view the
    > old details they could change in the form field.

![](vertopal_028555db347b44f2bf226a6a7176665b/media/image34.jpeg){width="8.499998906386702in"
height="5.99375in"}

-   User can upload an image file type for the menu item they're adding.

-   User can submit details; we check if they're sure with their
    > actions.

![](vertopal_028555db347b44f2bf226a6a7176665b/media/image35.jpeg){width="8.499998906386702in"
height="5.975in"}

-   If this is a new menu item then we'll insert the image and the other
    > details directly to the database.

-   If not, then we continue to else statement.

![](vertopal_028555db347b44f2bf226a6a7176665b/media/image36.jpeg){width="8.499998906386702in"
height="6.028472222222222in"}

-   Since database has old details, we have to check if the user
    > inserted a new image; if not, then the details will be updated
    > without the image.

![](vertopal_028555db347b44f2bf226a6a7176665b/media/image37.jpeg){width="8.499998906386702in"
height="6.047916666666667in"}

-   After updating/inserting menu item record, we disable the form
    > fields and update the menu items list.

-   ClearFormFields_Click clears all the form fields for the user.

-   DeleteItem_Click allows the user to delete the menu item from the
    > database.

## ![](vertopal_028555db347b44f2bf226a6a7176665b/media/image38.jpeg){width="8.499998906386702in" height="6.6704155730533685in"}CompleteMenu.cs

-   ExitButton_Click checks if customer wants to cancel their order and
    > return to splash screen.

-   CurrentOrder_Tick gets the details of the current cart from the
    > Order object created at the start, then displays it in an
    > OrderedItem user control in the flow layout cart panel.

-   CompleteMenu_Load gets the logo from database and display it in
    > picture box.

![](vertopal_028555db347b44f2bf226a6a7176665b/media/image39.jpeg){width="8.499998906386702in"
height="7.647916666666666in"}

-   retrieveItems gets all the menu items depending on the selected
    > category, and displays it in a MenuItem user control in a flow
    > layout panel.

-   Each button click event below activates the retrieveItems function
    > that changes which menu items are displayed.

![](vertopal_028555db347b44f2bf226a6a7176665b/media/image40.jpeg){width="8.499998906386702in"
height="6.157638888888889in"}

-   Checkout button checks if cart has items, if not then show a message
    > error.

-   If all good, then it sends new order to database.

![](vertopal_028555db347b44f2bf226a6a7176665b/media/image41.jpeg){width="8.499998906386702in"
height="7.148611111111111in"}

-   After inserting order in database, it creates a new text file in the
    > form of a receipt that can be printed.

## ![](vertopal_028555db347b44f2bf226a6a7176665b/media/image42.jpeg){width="8.499998906386702in" height="7.5072222222222225in"}MenuItem.cs

-   Setters and getters that is used to change the menu item details in
    > the complete menu user control.

-   AddItem_Click inserts that selected menu items into the cart.

## ![](vertopal_028555db347b44f2bf226a6a7176665b/media/image43.jpeg){width="8.499998906386702in" height="7.499305555555556in"}OrderedItem.cs

-   Setters and getters that is used to change the cart item details in
    > the checkout panel.

-   quantityAdd_Click and quantityMinus_Click changes the specific cart
    > item quantity.

## ![](vertopal_028555db347b44f2bf226a6a7176665b/media/image44.jpeg){width="8.499998906386702in" height="6.755in"}Order.cs

-   Array that can contain up to 100 unique items in a single cart.

-   GetTotal function gets the total of the cart and returns it.

-   InsertItem checks if item exists, if not then adds it as a new item.
    > If it exists then it changes quantity of item.

![](vertopal_028555db347b44f2bf226a6a7176665b/media/image45.jpeg){width="8.499998906386702in"
height="7.020555555555555in"}

-   DecreaseItem function decreases the quantity of item, if the item
    > reaches 0 quantity it is deleted from the array (cart).

-   ClearAll function deletes all items from the cart.

## ![](vertopal_028555db347b44f2bf226a6a7176665b/media/image46.jpeg){width="8.499998906386702in" height="6.914861111111111in"}PasswordChecker.cs

-   SubmitPassword_Click checks if password entered in the text field is
    > the same as in the database.

-   Password_KeyDown allows user to press enter to submit password
    > instead of clicking button.

## ![](vertopal_028555db347b44f2bf226a6a7176665b/media/image47.jpeg){width="8.499998906386702in" height="6.92638779527559in"}Program.cs

-   At the start of the application, check if owner of restaurant
    > submitted their details; if not then start the start up before the
    > main menu.
