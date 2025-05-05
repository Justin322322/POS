-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 05, 2025 at 02:41 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `grocery_pos`
--

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE `categories` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `description` text DEFAULT NULL,
  `created_at` datetime DEFAULT current_timestamp(),
  `updated_at` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`id`, `name`, `description`, `created_at`, `updated_at`) VALUES
(2, 'chips', 'asddds', '2025-04-21 03:16:46', '2025-04-21 03:16:46'),
(3, 'Beverages', 'Drinks and liquids for consumption', '2025-04-21 12:47:19', '2025-04-21 12:47:19'),
(4, 'Bakery', 'Bread, pastries, and baked goods', '2025-04-21 12:47:19', '2025-04-21 12:47:19'),
(5, 'Canned Goods', 'Preserved food in cans or jars', '2025-04-21 12:47:19', '2025-04-21 12:47:19'),
(6, 'Dairy', 'Milk, cheese, and other dairy products', '2025-04-21 12:47:19', '2025-04-21 12:47:19'),
(7, 'Dry/Baking Goods', 'Flour, sugar, cereal, and baking items', '2025-04-21 12:47:19', '2025-04-21 12:47:19'),
(8, 'Frozen Foods', 'Frozen meals, vegetables, and desserts', '2025-04-21 12:47:19', '2025-04-21 12:47:19'),
(9, 'Meat', 'Beef, pork, poultry, and seafood', '2025-04-21 12:47:19', '2025-04-21 12:47:19'),
(10, 'Produce', 'Fruits and vegetables', '2025-04-21 12:47:19', '2025-04-21 12:47:19'),
(11, 'Cleaners', 'Household cleaning products', '2025-04-21 12:47:19', '2025-04-21 12:47:19'),
(12, 'Paper Goods', 'Paper towels, toilet paper, etc.', '2025-04-21 12:47:19', '2025-04-21 12:47:19'),
(13, 'Personal Care', 'Soap, shampoo, toothpaste, etc.', '2025-04-21 12:47:20', '2025-04-21 12:47:20'),
(14, 'Other', 'Miscellaneous items', '2025-04-21 12:47:20', '2025-04-21 12:47:20');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `category_id` int(11) DEFAULT NULL,
  `price` decimal(10,2) NOT NULL,
  `stock` int(11) NOT NULL DEFAULT 0,
  `barcode` varchar(50) DEFAULT NULL,
  `created_at` datetime DEFAULT current_timestamp(),
  `updated_at` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`id`, `name`, `category_id`, `price`, `stock`, `barcode`, `created_at`, `updated_at`) VALUES
(1, 'piattos', 2, 11.00, 77, '123123', '2025-04-21 03:22:10', '2025-04-21 12:32:16'),
(2, 'Milk 1L', 6, 2.99, 50, '123456789', '2025-04-21 12:47:20', '2025-04-21 12:47:20'),
(3, 'White Bread', 4, 1.99, 30, '234567890', '2025-04-21 12:47:20', '2025-04-21 12:47:20'),
(4, 'Eggs (12pk)', 6, 3.49, 40, '345678901', '2025-04-21 12:47:20', '2025-04-21 12:47:20'),
(5, 'Coke 2.5 L', 3, 89.00, 98, '456789012', '2025-04-21 12:47:20', '2025-04-25 00:49:44'),
(6, 'Chicken Breast 1kg', 9, 8.99, 22, '567890123', '2025-04-21 12:47:20', '2025-04-30 08:01:09'),
(7, 'Bananas 1kg', 10, 1.99, 98, '678901234', '2025-04-21 12:47:20', '2025-04-25 00:49:44'),
(8, 'Toilet Paper 12pk', 12, 9.99, 30, '789012345', '2025-04-21 12:47:20', '2025-04-21 12:47:20'),
(9, 'Dish Soap', 11, 3.49, 45, '890123456', '2025-04-21 12:47:20', '2025-04-21 12:47:20'),
(10, 'Canned Tuna', 5, 1.79, 76, '901234567', '2025-04-21 12:47:20', '2025-04-30 08:01:09'),
(11, 'Rice 5kg', 7, 12.99, 20, '012345678', '2025-04-21 12:47:20', '2025-04-21 12:47:20'),
(12, 'Alaska Powdered Milk 80g', 6, 49.50, 49, '4800092100123', '2025-04-21 12:56:13', '2025-04-24 20:16:11'),
(13, 'Gardenia Classic White Bread', 4, 87.75, 30, '4800092200123', '2025-04-21 12:56:13', '2025-04-21 12:56:13'),
(14, 'Magnolia Chicken Eggs (6pcs)', 6, 52.50, 40, '4800092300123', '2025-04-21 12:56:13', '2025-04-21 12:56:13'),
(16, 'Magnolia Chicken Breast 1kg', 9, 220.00, 25, '4800092500123', '2025-04-21 12:56:13', '2025-04-21 12:56:13'),
(17, 'Saba Banana (1kg)', 10, 60.00, 100, '4800092600123', '2025-04-21 12:56:13', '2025-04-21 12:56:13'),
(18, 'Tissue Roll 12pcs', 12, 180.00, 30, '4800092700123', '2025-04-21 12:56:13', '2025-04-21 12:56:13'),
(19, 'Joy Dishwashing Liquid 250ml', 11, 45.75, 45, '4800092800123', '2025-04-21 12:56:13', '2025-04-21 12:56:13'),
(20, 'Century Tuna Flakes 155g', 5, 40.00, 97, '4800092900123', '2025-04-21 12:56:13', '2025-04-30 08:01:09'),
(21, 'Jasmine Rice 5kg', 7, 275.00, 20, '4800093000123', '2025-04-21 12:56:13', '2025-04-21 12:56:13'),
(22, 'Lucky Me Pancit Canton 6pcs', 7, 75.50, 40, '4800093100123', '2025-04-21 12:56:13', '2025-04-21 12:56:13'),
(23, 'Milo 300g', 3, 99.75, 35, '4800093200123', '2025-04-21 12:56:13', '2025-04-21 12:56:13'),
(24, 'Nescafe 3-in-1 Original 30x20g', 3, 125.50, 30, '4800093300123', '2025-04-21 12:56:13', '2025-04-21 12:56:13'),
(25, 'Piattos Cheese 85g', 7, 32.75, 50, '4800093400123', '2025-04-21 12:56:13', '2025-04-21 12:56:13'),
(26, 'Safeguard Soap 135g', 13, 42.50, 40, '4800093500123', '2025-04-21 12:56:13', '2025-04-21 12:56:13'),
(27, 'Head & Shoulders Shampoo 180ml', 13, 119.75, 25, '4800093600123', '2025-04-21 12:56:13', '2025-04-21 12:56:13'),
(28, 'Colgate Toothpaste 150g', 13, 85.25, 34, '4800093700123', '2025-04-21 12:56:13', '2025-04-21 13:19:47'),
(29, 'Del Monte Spaghetti Sauce 250g', 5, 42.75, 39, '4800093800123', '2025-04-21 12:56:13', '2025-04-21 13:19:47'),
(30, 'Spaghetti Pasta 1kg', 7, 72.50, 30, '4800093900123', '2025-04-21 12:56:13', '2025-04-21 12:56:13'),
(31, 'Condensed Milk 300ml', 6, 55.25, 44, '4800094000123', '2025-04-21 12:56:13', '2025-04-21 13:19:47'),
(32, 'Coca Cola 1.5L', 3, 63.25, 59, '4800092400123', '2025-04-21 13:02:55', '2025-04-30 08:00:43');

-- --------------------------------------------------------

--
-- Table structure for table `transactions`
--

CREATE TABLE `transactions` (
  `id` int(11) NOT NULL,
  `user_id` int(11) DEFAULT NULL,
  `transaction_date` datetime DEFAULT current_timestamp(),
  `total_amount` decimal(10,2) NOT NULL,
  `amount_paid` decimal(10,2) NOT NULL,
  `change_amount` decimal(10,2) NOT NULL,
  `payment_method` varchar(20) NOT NULL DEFAULT 'Cash'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `transactions`
--

INSERT INTO `transactions` (`id`, `user_id`, `transaction_date`, `total_amount`, `amount_paid`, `change_amount`, `payment_method`) VALUES
(1, 1, '2025-04-21 03:57:59', 11.00, 70.00, 59.00, 'Cash'),
(4, 1, '2025-04-21 04:09:48', 11.00, 400.00, 389.00, 'Cash'),
(5, 1, '2025-04-21 04:19:05', 11.00, 50.00, 39.00, 'Cash'),
(7, 1, '2025-04-21 04:24:16', 11.00, 80.00, 69.00, 'Cash'),
(8, 1, '2025-04-21 04:26:04', 11.00, 60.00, 49.00, 'Cash'),
(9, 1, '2025-04-21 04:35:08', 11.00, 700.00, 689.00, 'Cash'),
(10, 1, '2025-04-21 04:47:53', 22.00, 522.00, 500.00, 'Cash'),
(11, 1, '2025-04-21 08:39:59', 11.00, 511.00, 500.00, 'Cash'),
(12, 1, '2025-04-21 08:45:20', 11.00, 111.00, 100.00, 'Cash'),
(13, 1, '2025-04-21 08:56:15', 11.00, 511.00, 500.00, 'Cash'),
(14, 1, '2025-04-21 09:07:01', 11.00, 11.00, 0.00, 'Card'),
(15, 1, '2025-04-21 09:17:59', 11.00, 11.00, 0.00, 'Cash'),
(16, 1, '2025-04-21 10:05:22', 11.00, 1011.00, 1000.00, 'Cash'),
(17, 1, '2025-04-21 10:44:36', 11.00, 1000.00, 989.00, 'Cash'),
(18, 1, '2025-04-21 10:48:31', 11.00, 1000.00, 989.00, 'Cash'),
(19, 1, '2025-04-21 10:53:06', 11.00, 6611.00, 6600.00, 'Cash'),
(20, 1, '2025-04-21 11:25:02', 11.00, 1000.00, 989.00, 'Cash'),
(21, 1, '2025-04-21 11:34:56', 11.00, 1000.00, 989.00, 'Cash'),
(22, 1, '2025-04-21 12:32:16', 11.00, 1000.00, 989.00, 'Cash'),
(23, 1, '2025-04-21 13:19:47', 321.53, 500.00, 178.47, 'Cash'),
(24, 1, '2025-04-24 20:16:11', 53.28, 1000.00, 946.72, 'Cash'),
(25, 1, '2025-04-25 00:49:44', 141.77, 500.00, 358.23, 'Cash'),
(26, 1, '2025-04-30 08:00:43', 103.25, 1000.00, 896.75, 'Cash'),
(27, 1, '2025-04-30 08:01:09', 50.78, 1000.00, 949.22, 'Cash');

-- --------------------------------------------------------

--
-- Table structure for table `transaction_items`
--

CREATE TABLE `transaction_items` (
  `id` int(11) NOT NULL,
  `transaction_id` int(11) DEFAULT NULL,
  `product_id` int(11) DEFAULT NULL,
  `product_name` varchar(100) NOT NULL,
  `price` decimal(10,2) NOT NULL,
  `quantity` int(11) NOT NULL,
  `subtotal` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `transaction_items`
--

INSERT INTO `transaction_items` (`id`, `transaction_id`, `product_id`, `product_name`, `price`, `quantity`, `subtotal`) VALUES
(1, 1, 1, 'piattos', 11.00, 1, 11.00),
(4, 4, 1, 'piattos', 11.00, 1, 11.00),
(5, 5, 1, 'piattos', 11.00, 1, 11.00),
(7, 7, 1, 'piattos', 11.00, 1, 11.00),
(8, 8, 1, 'piattos', 11.00, 1, 11.00),
(9, 9, 1, 'piattos', 11.00, 1, 11.00),
(10, 10, 1, 'piattos', 11.00, 2, 22.00),
(11, 11, 1, 'piattos', 11.00, 1, 11.00),
(12, 12, 1, 'piattos', 11.00, 1, 11.00),
(13, 13, 1, 'piattos', 11.00, 1, 11.00),
(14, 14, 1, 'piattos', 11.00, 1, 11.00),
(15, 15, 1, 'piattos', 11.00, 1, 11.00),
(16, 16, 1, 'piattos', 11.00, 1, 11.00),
(17, 17, 1, 'piattos', 11.00, 1, 11.00),
(18, 18, 1, 'piattos', 11.00, 1, 11.00),
(19, 19, 1, 'piattos', 11.00, 1, 11.00),
(20, 20, 1, 'piattos', 11.00, 1, 11.00),
(21, 21, 1, 'piattos', 11.00, 1, 11.00),
(22, 22, 1, 'piattos', 11.00, 1, 11.00),
(23, 23, 10, 'Canned Tuna', 1.79, 1, 1.79),
(24, 23, 20, 'Century Tuna Flakes 155g', 38.50, 1, 38.50),
(25, 23, 6, 'Chicken Breast 1kg', 8.99, 1, 8.99),
(26, 23, 5, 'Coke 2.5 L', 89.00, 1, 89.00),
(27, 23, 28, 'Colgate Toothpaste 150g', 85.25, 1, 85.25),
(28, 23, 31, 'Condensed Milk 300ml', 55.25, 1, 55.25),
(29, 23, 29, 'Del Monte Spaghetti Sauce 250g', 42.75, 1, 42.75),
(30, 24, 12, 'Alaska Powdered Milk 80g', 49.50, 1, 49.50),
(31, 24, 7, 'Bananas 1kg', 1.99, 1, 1.99),
(32, 24, 10, 'Canned Tuna', 1.79, 1, 1.79),
(33, 25, 7, 'Bananas 1kg', 1.99, 1, 1.99),
(34, 25, 10, 'Canned Tuna', 1.79, 1, 1.79),
(35, 25, 20, 'Century Tuna Flakes 155g', 40.00, 1, 40.00),
(36, 25, 6, 'Chicken Breast 1kg', 8.99, 1, 8.99),
(37, 25, 5, 'Coke 2.5 L', 89.00, 1, 89.00),
(38, 26, 20, 'Century Tuna Flakes 155g', 40.00, 1, 40.00),
(39, 26, 32, 'Coca Cola 1.5L', 63.25, 1, 63.25),
(40, 27, 10, 'Canned Tuna', 1.79, 1, 1.79),
(41, 27, 20, 'Century Tuna Flakes 155g', 40.00, 1, 40.00),
(42, 27, 6, 'Chicken Breast 1kg', 8.99, 1, 8.99);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `full_name` varchar(100) NOT NULL,
  `role` varchar(20) NOT NULL DEFAULT 'Cashier',
  `created_at` datetime DEFAULT current_timestamp(),
  `updated_at` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `password`, `full_name`, `role`, `created_at`, `updated_at`) VALUES
(1, 'admin', 'admin123', 'Administrator', 'Admin', '2025-04-21 01:26:10', '2025-04-21 01:26:10');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`id`),
  ADD KEY `category_id` (`category_id`);

--
-- Indexes for table `transactions`
--
ALTER TABLE `transactions`
  ADD PRIMARY KEY (`id`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `transaction_items`
--
ALTER TABLE `transaction_items`
  ADD PRIMARY KEY (`id`),
  ADD KEY `transaction_id` (`transaction_id`),
  ADD KEY `product_id` (`product_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `categories`
--
ALTER TABLE `categories`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;

--
-- AUTO_INCREMENT for table `transactions`
--
ALTER TABLE `transactions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- AUTO_INCREMENT for table `transaction_items`
--
ALTER TABLE `transaction_items`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=43;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `products`
--
ALTER TABLE `products`
  ADD CONSTRAINT `products_ibfk_1` FOREIGN KEY (`category_id`) REFERENCES `categories` (`id`);

--
-- Constraints for table `transactions`
--
ALTER TABLE `transactions`
  ADD CONSTRAINT `transactions_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);

--
-- Constraints for table `transaction_items`
--
ALTER TABLE `transaction_items`
  ADD CONSTRAINT `transaction_items_ibfk_1` FOREIGN KEY (`transaction_id`) REFERENCES `transactions` (`id`),
  ADD CONSTRAINT `transaction_items_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `products` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
