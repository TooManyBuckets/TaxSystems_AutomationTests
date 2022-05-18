Title: Tax Systems - Automation Test Pack 
Author: Charles Walker

This solution has been created to cover the following tests steps as required by the brief:
  - Launch browser, or in headless mode
  - Go to website
  - Search for “Printed Summer Dress” and find result (priced indv. at $28.98)
  - Configure selection – so you get the dress you want
  - Change to blue colour
  - Change to M size
  - Quantity 2
  - Add to basket and confirm in resulting pop up the total value
  - proceed to checkout
  - validate the basket values/elements 
  - update quantity to 3 dresses and validate the updated values.
  - complete checkout (optional)

While not a very elegant, or even a correct solution, this is unfortunately an accurate reproduction of how the inhouse tool of our automation team runs. In order to run these tests, it is simply an instance of running the build. On a successful build, we mark the test as complete. On a failed build, we can view the exact step that it failed on.
